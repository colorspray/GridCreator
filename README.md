# GridCreator

A Unity tool to create hex grid map 
<br/>

### Possible usage:
turn-based strategy games

### How to use:
TerrainGrid: the gameobject used to create a grid map
TerrainTileHex: the prefab for the tile info used to create the grid map

Drag ProjectAssets/GameObject/TerrainGrid into your scene,
Edit Rows and Columns in Inspector panel of TerrainGrid gameObject, 
drag a TerrainTile prefab (with the TerrainTile script) into Terrain Tile blanket,
then click 'Clear and create grid';

Click a tile and Change TerrainType in Inspector;

the ProjectAssets/GameObject/TerrainTileHex is a precreated TerrainTile, you can edit the material list for tile. 
premade materials in Material folder is using textures from TerrainAssets in standardAssets please import or make your own material instead

### TODO:
* rewrite the materialList inspector, using the info of the terrain enum;
* brush tool to edit terrain materail;
* add links(path) between tiles, add weight for links, then path-finding tools;
* place holders for static scene object and dynamic actors;

