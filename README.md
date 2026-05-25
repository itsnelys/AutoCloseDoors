# AutoCloseDoors

## FR

Script minimal pour Programmable Block *Space Engineers*.

Il ferme automatiquement les portes qui appartiennent a un groupe dont le nom contient `AUTOCLOSEDOOR`. Les autres portes ne sont pas touchees.

### Installation

1. Place un `Programmable Block`.
2. Copie le contenu de `Program.cs` dans le Programmable Block.
3. Cree un groupe de portes avec `AUTOCLOSEDOOR` dans son nom.
4. Compile et lance le script.

### Exemples de groupes

- `AUTOCLOSEDOOR`
- `AUTOCLOSEDOOR Hangar`
- `AUTOCLOSEDOOR Base`

### Reglages

Dans `Program.cs` :

| Reglage | Valeur par defaut | Description |
| --- | --- | --- |
| `GROUP_TAG` | `AUTOCLOSEDOOR` | Texte cherche dans les noms de groupes. |
| `AUTOCLOSE_SECONDS` | `4.0` | Delai avant fermeture automatique. |
| `SCAN_SECONDS` | `5.0` | Frequence de detection des groupes. |

### Commande

| Commande | Action |
| --- | --- |
| `scan` | Recharge la liste des groupes et des portes. |

### Limite

Le script ne gere que les portes sur la meme grille que le Programmable Block.

### Note de patch 0.1

- Premiere version documentee.
- Fermeture automatique des portes dans les groupes `AUTOCLOSEDOOR`.
- Commande `scan` pour rafraichir la detection.
- Limitation volontaire a la grille du Programmable Block.

---

## EN

Minimal *Space Engineers* Programmable Block script.

It automatically closes only doors that belong to a group whose name contains `AUTOCLOSEDOOR`. Other doors are left untouched.

### Installation

1. Place a `Programmable Block`.
2. Copy `Program.cs` into the Programmable Block.
3. Create a door group with `AUTOCLOSEDOOR` in its name.
4. Compile and run the script.

### Group Examples

- `AUTOCLOSEDOOR`
- `AUTOCLOSEDOOR Hangar`
- `AUTOCLOSEDOOR Base`

### Settings

In `Program.cs`:

| Setting | Default Value | Description |
| --- | --- | --- |
| `GROUP_TAG` | `AUTOCLOSEDOOR` | Text searched in group names. |
| `AUTOCLOSE_SECONDS` | `4.0` | Delay before automatic closing. |
| `SCAN_SECONDS` | `5.0` | Group detection refresh interval. |

### Command

| Command | Action |
| --- | --- |
| `scan` | Reloads the group and door list. |

### Limitation

The script only manages doors on the same grid as the Programmable Block.

### Patch Note 0.1

- First documented release.
- Automatic door closing for doors in `AUTOCLOSEDOOR` groups.
- Added `scan` command to refresh detection.
- Intentionally limited to the Programmable Block grid.

---

## License & Author

Provided by **soraanoir/sundae https://github.com/soraanoir**.  
Free to use and modify, provided that credit is given to the author.
