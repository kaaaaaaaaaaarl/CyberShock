# CyberShock
An open source unity 2019.4.31f1 Rythem game inspired by cybercore and rave scenes. 
- New levels, texurepacks and mods are easy to add and create. More on their creation is lower in the README
- You can add comunity made maps by following @Custom maps
- High scores are stored globaly
- 

## Install guide
Un-zip the contents of the release and run the Cybershock.exe file.

## Moding the game, not creating
### Custom maps
If you want to add a custom map, go to the cybershock/assets/map-data and unzip(if needed) the map you have downloaded or created.
### Custom assets and textures
You can place the unziped and properly organized and named textures in the them in the cybershock/assets/Texturepacks
### Mods and addons
Follow the mod creators instructions.

## Creating custom maps and texturepacks for the game
### Custom maps
#### JSON file
- Name the json file "mapData-*Level name here*"
- All values are stored in a BeatMap array like this {"BeatMap":[*map data here*]}
- BPM represents the songs Beat Per Minute, this can be auto generated, but its highly recomended that you look at the song you are adding and its BPM.
- level represents the dificlty and the color it will show up on in the menu
- arrows will be 4 numbers long, the 1st one is ignored(1-9, if you type a 0 Json will not count it as a number and break), the next 3 will represent the arrows. The position of it will represent where in the lane it will appear for example 6100 will be to the left lane and 6001 will be to the right
> if the notation is too short it will interprete it as a 0. For example 6100, 610 and 61 will all work the same.
- the notations are:
-- 1
-- 2
### Custom assets and textures
You can place the unziped and properly organized and named textures in the them in the cybershock/assets/Texturepacks
### Mods and addons
Follow the mod creators instructions.

{
    "BeatMap": [
        {
            "BPM": 120,
            "arrows": [
                6111,
                6100,
                6010,
                6001,
                6100,
                6100,
                6100,
                6101,
                6888,
                6888,
                6888
            ]
        }
    ]
}
