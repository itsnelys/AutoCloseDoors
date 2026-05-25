// Space Engineers Programmable Block script
// AutoCloseDoors - close only doors inside named groups.

const string GROUP_TAG = "AUTOCLOSEDOOR";
const double AUTOCLOSE_SECONDS = 4.0;
const double SCAN_SECONDS = 5.0;

readonly List<IMyDoor> _doors = new List<IMyDoor>();
readonly List<IMyBlockGroup> _groups = new List<IMyBlockGroup>();
readonly Dictionary<long, double> _doorOpenSince = new Dictionary<long, double>();

double _elapsed;
double _scanTimer = SCAN_SECONDS;

public Program()
{
    Runtime.UpdateFrequency = UpdateFrequency.Update10;
    ScanDoors();
}

public void Main(string argument, UpdateType updateSource)
{
    _elapsed += Runtime.TimeSinceLastRun.TotalSeconds;
    _scanTimer += Runtime.TimeSinceLastRun.TotalSeconds;

    if (_scanTimer >= SCAN_SECONDS || IsCommand(argument, "scan"))
    {
        ScanDoors();
        _scanTimer = 0;
    }

    AutoCloseDoors();
    EchoStatus();
}

void ScanDoors()
{
    _doors.Clear();
    _groups.Clear();

    GridTerminalSystem.GetBlockGroups(_groups, group => HasGroupTag(group));

    for (int i = 0; i < _groups.Count; i++)
        AddGroupDoors(_groups[i]);
}

void AddGroupDoors(IMyBlockGroup group)
{
    List<IMyDoor> groupDoors = new List<IMyDoor>();
    group.GetBlocksOfType(groupDoors, door => door.CubeGrid == Me.CubeGrid);

    for (int i = 0; i < groupDoors.Count; i++)
    {
        if (!ContainsDoor(groupDoors[i]))
            _doors.Add(groupDoors[i]);
    }
}

void AutoCloseDoors()
{
    for (int i = 0; i < _doors.Count; i++)
    {
        IMyDoor door = _doors[i];
        long id = door.EntityId;

        if (door.Status == DoorStatus.Open)
        {
            if (!_doorOpenSince.ContainsKey(id))
                _doorOpenSince[id] = _elapsed;

            if (_elapsed - _doorOpenSince[id] >= AUTOCLOSE_SECONDS)
                door.CloseDoor();
        }
        else if (door.Status == DoorStatus.Closed || door.Status == DoorStatus.Closing)
        {
            _doorOpenSince.Remove(id);
        }
    }
}

void EchoStatus()
{
    Echo("AUTOCLOSEDOORS");
    Echo("Groupes: " + _groups.Count);
    Echo("Portes gerees: " + _doors.Count);
    Echo("Delai: " + AUTOCLOSE_SECONDS.ToString("0") + "s");
    Echo("Tag groupe: " + GROUP_TAG);
}

bool HasGroupTag(IMyBlockGroup group)
{
    return group.Name.IndexOf(GROUP_TAG, StringComparison.OrdinalIgnoreCase) >= 0;
}

bool ContainsDoor(IMyDoor door)
{
    long id = door.EntityId;

    for (int i = 0; i < _doors.Count; i++)
    {
        if (_doors[i].EntityId == id)
            return true;
    }

    return false;
}

bool IsCommand(string argument, string command)
{
    return argument != null && argument.Trim().Equals(command, StringComparison.OrdinalIgnoreCase);
}
