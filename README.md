# Gheist Heist
[![forthebadge](https://forthebadge.com/images/badges/made-with-c-sharp.svg)](https://dotnet.microsoft.com/en-us/languages/csharp)
[![forthebadge](https://forthebadge.com/images/badges/60-percent-of-the-time-works-every-time.svg)](https://randommadeuplinkthathopefulywontwork.com)
[![forthebadge](https://forthebadge.com/images/badges/not-a-bug-a-feature.svg)](https://devhumor.com/content/uploads/images/June2018/root-cause.png)
[![forthebadge](https://forthebadge.com/images/badges/works-on-my-machine.svg)](https://images.shopcdn.co.uk/73/00/73009e54030c99f47788f0cd42549e32/2048x2048/webp/resize?t=1719572167)
[![forthebadge](https://forthebadge.com/images/badges/built-with-love.svg)](https://media.tenor.com/AkNak8NFhbMAAAAj/beating-heart.gif)
<br>
> Simple fast-paced platformer that tests on-the-spot decision-making, optimal path-finding, and precise maneuvering
# Table of contents

- [Usage](#usage)
- [Objective](#objective)
- [Controls](#controls)
- [Installation](#installation)
- [Recommended specs](#recommended-specs)
- [Updating](#updating)
- [Uninstallation](#uninstallation)
- [Programmer Manual](#programmer-manual)
- [Credits](#credits)
- [License](#license)

# Usage

- There is no clear use other than relaxation and fun.

[(Back to top)](#table-of-contents)

# Objective

- As summarised in the description this game is a platformer however, we have incorporated a little twist. You are not platforming alone, just a few seconds behind you is a ghost, a monster if you will, shadowing you taking the same path you did. The minor difference is, that it ignores any unnecessary movements.
- Your objective is to uncover the secred burried deep on the military base. You need special glasses to see the special door of the `Sector D`, however those glasses have been broken thus it forces you to search the remaining 3 Sectors for their `Shards`.

[(Back to top)](#table-of-contents)

# Controls

- Menu Navigation: ( `Mouse 🖱️` )
- Jump ( `↑` / `W` )
- Run right ( `→` / `D` )
- Run left ( `←` / `A` )
- Fast fall ( `↓` / `S` )

[(Back to top)](#table-of-contents)

# Installation

- Download the Gheist Heist Windows Build. Open and Run the `.exe` file

[(Back to top)](#table-of-contents)

# Recommended specs

- The game's current build only runs on Windows 7 and newer for other versions you would have to pull the project and make a custom build using Unity.

[(Back to top)](#table-of-contents)

# Updating

- The game does not support auto-update for newer versions you have to download them from GitHub manually.

[(Back to top)](#table-of-contents)

# Uninstallation

- Uninstalling is simple, find the game folder and delete it form the device. The game does not create any additional folders/files outside of the game folder.

[(Back to top)](#table-of-contents)

# Programmer Manual

- This project was made with Unity version: `2022.3.13f1`

1. Scenes (.unity)
 * Purpose: Scenes are the individual levels or areas of your game. They contain all the objects, components, and interactions that define a specific gameplay experience.
 * Content: Scenes typically include:
   * Game objects (e.g., characters, enemies, cameras)
   * Components (e.g., scripts, colliders, renderers)
   * Lighting settings
   * Terrain and environment elements
2. Prefabs (.prefab)
 * Purpose: Prefabs are reusable assets that can be instantiated multiple times within a scene. They provide a way to create consistent elements across your game.
 * Content: Prefabs can contain:
   * Game objects
   * Components
   * Hierarchies of objects
3. Materials (.mat)
 * Purpose: Materials define the appearance of objects in your scene, including color, texture, and shading properties.
 * Content: Materials typically include:
   * Albedo (base color)
   * Specular (shininess)
   * Metallic (reflectiveness)
   * Smoothness
   * Texture maps (e.g., diffuse, normal, specular)
4. Textures (.png, .jpg, .tga, etc.)
 * Purpose: Textures provide visual details for objects and materials.
 * Content: Textures can be used for:
   * Albedo
   * Normal maps
   * Specular maps
   * Occlusion maps
   * Heightmaps
5. Scripts (.cs)
 * Purpose: Scripts are programming components that define the behavior of game objects. They handle interactions, logic, and game mechanics.
 * Content: Scripts can include:
   * C#
   * Functions
   * Variables
   * Event handlers
6. Assets (.asset)
 * Purpose: Assets are generic data files used by Unity. They can store various types of information, such as animations, audio clips, and custom data.
 * Content: Assets can be created or imported into the project.
Additional Considerations
 * Project Settings: These settings control global aspects of your project, such as player settings, physics settings, and scripting define.
 * Folders: Organize your project files into folders for better management and maintainability.

- Algorithms:
  * Enemy AI - Uses a list with timestamped locations of the player and calculates the new target location of the enemy based on this information. The algoritm optimizes the path taken neglecting small movements and ignoring insufficiently sized movements.
  * Background Parallax - This algorithm averages the center of the frame with the player's location thus creating illusion of depth.
  * Air Friction - Handles all player friction by multiplying the drag coefition with time in between frame calculations. This enables drag to be customizable thus ensuring personalized calibration.
 
- Special Implementations:
   * Singleton - Sound Effect Script, Scene Manager Script, Memory Manager Script - THis ensured data transfer inbetween scenes

[(Back to top)](#table-of-contents)

# Credits

- Unity project developer: `Timotej Kotlín`
- Chief of Design / Project Manager: `Nikolas Ján Hamarik`
- SoundFX / Music and Level Design: `Samuel Lipovský`

[(Back to top)](#table-of-contents)

# License

- Open Source License

[(Back to top)](#table-of-contents)

# Conclusion

- We are happy with how the project turned out. The greatest obstacle to overcome was the organization of our team. Code-wise the hardest feature to implement was the Memory script due to a bug with its temporary list erasing thus creating overlapping level collectibles. Futute additions we would like to implement include but are not limited to:
  * More animations including player movement animation
  * Rewamp of the memory script into a serializable script, enabling game data saving inbetween gaming sessions using on device files.

[(Back to top)](#table-of-contents)
