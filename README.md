### Unity build log analyzer

Converts Unity console build log into CSV format ASSET_PATH/ASSET_TYPE/BUILD_DURATION, for build optimization.


### Usage 

```
Unity3d Build Log Analyzer v.1.0.0
Usage: 
	input_filename output_filename [filter]
	Possible filter types: 
		Texture(.tga .png .bmp .jpg)
		Code(.cs .json .py .txt)
		Mesh(.fbx .obj)
		Lightmap(.exr .cubemap)
		UnityAsset(.prefab .unity .anim .shader .asset .mat)
		Audio(.wav .sfk .ogg)
		Other()

		You can combine more filters using | separator, or like this: 
		Texture|Lightmap|Code
```