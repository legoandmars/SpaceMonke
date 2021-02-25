# Space Monke

A PC Gorilla Tag mod that makes your jumps super huge.
## Installation

### Automatic installation
If you don't want to manually install, you can install this mod with the [Monke Mod Manager](https://github.com/DeadlyKitten/MonkeModManager/releases/latest)
### Manual Installation

If your game isn't modded with BepinEx, DO THAT FIRST! Simply go to the [latest BepinEx release](https://github.com/BepInEx/BepInEx/releases) and extract BepinEx_x64_VERSION.zip directly into your game's folder, then run the game once to install BepinEx properly.

This mod requires Utilla, so download it here: https://github.com/legoandmars/Utilla/releases/latest - Make sure to follow the installation instructions!

Next, go to the [latest release of this mod](https://github.com/legoandmars/SpaceMonke/releases/latest) and extract it directly into your game's folder. Make sure it's extracted directly into your game's folder and not into a subfolder!

## Configuration

If you'd like to change how extreme the jump effect is, run the game once to generate a config found in `Gorilla Tag/BepInEx/config/SpaceMonke.cfg`

The config should be mostly self-explanatory, here's a quick rundown of what it does:
```
[Configuration]

# How much to multiply the jump height/distance by. 10 = 10x higher jumps
# Default value: 10
JumpMultiplier = 10
```

## For Developers
This project is built with C# using .NET Standard.

For references, create a Libs folder in the same folder as the project solution. Inside of this folder you'll need to copy:

```
0Harmony.dll
BepInEx.dll
BepInEx.Harmony.dll
``` 
from `Gorilla Tag\BepInEx\core`,
```
Utilla.dll
``` 
from `Gorilla Tag\BepInEx\plugins`, and
```
Assembly-CSharp.dll
UnityEngine.dll
UnityEngine.CoreModule.dll
``` 
from `Gorilla Tag\Gorilla Tag_Data\Managed`.