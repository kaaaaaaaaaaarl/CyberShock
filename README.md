# CyberShock
An open source unity 2019.4.31f1 Rythem game inspired by cybercore and the rave scene. 
- New levels, texurepacks and mods are easy to add and create. More on their creation is lower in the README
- You can add comunity made maps by following @Custom maps
- High scores are stored globaly

## Install guide
Un-zip the contents of the release and run the Cybershock.exe file.

## Moding the game, not creating
This is for adding comunity made maps and resources.
### Custom maps
If you want to add a custom map, go to the cybershock/assets/map-data and unzip(if needed) the map you have downloaded or created.
### Custom assets and textures
You can place the unziped and properly organized and named textures in the them in the cybershock/assets/Texturepacks.
### Conversion mods and addons
Follow the mod creators instructions.

## Creating custom mods for the game
This is for understanding how the game understands maps, textures and their data. 
### Custom maps
This contains multiple sections. All of the files need to be placed in a folder with the name of the map collection.
#### JSON file formating
- Name the json file "mapData-*Level name here*"
- All values are stored in a BeatMap array like this {"BeatMap":[*map data here*]}
- BPM represents the songs Beat Per Minute, this can be auto generated, but its highly recomended that you look at the song you are adding and its BPM.
- level represents the dificlty and the color it will show up on in the menu
- arrows will be 4 numbers long, the 1st one is ignored(1-9, if you type a 0 Json will not count it as a number and break), the next 3 will represent the arrows. The position of it will represent where in the lane it will appear for example 6100 will be to the left lane and 6001 will be to the right
> If the notation is too short it will interprete it as a 0. For example 6100, 610 and 61 will all work the same.

#### JSON file values
This is how you represent each beat type (long short, arrow, spacebar).
- **1**- regular 1 press arrow
- **222**- regular 1 press spacebar
- **3**- start of a long arrow
- **444**- start of a long spacebar
- **5**- end of long press arrow
- **666**- end of long press spacebar
> **Important note** if any spacebar value is used once in a beat(for example 6040, 6020, or 6141) it will be ignored. Only if all rows are filed up with spacebar commands will it register.
> Incase there is no end of long press noted, it will stop on the next instance of the beat getting played, but wont play the beat itself.

#### Custom textures per beatmap
In the same folder you can place a folder called "customTextures" where it will use the same folder formation as a complete texturepack.

### Custom texturepack
#### File structure
