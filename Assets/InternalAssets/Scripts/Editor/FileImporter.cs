using System.Collections;
using UnityEditor;
using UnityEngine;

public class FileImporter : AssetPostprocessor
{
	void OnPreprocessModel ()
	{
		if (assetPath.Substring(assetPath.Length - 4, 4) == ".fbx") // Model is an FBX file
		{
			ModelImporter importer = assetImporter as ModelImporter;

			if (!importer)
				return;

			// Model
			importer.importMaterials = false;
			importer.importNormals = ModelImporterNormals.Calculate;
			importer.normalSmoothingAngle = 180;

			// Animation
			importer.importAnimation = assetPath.Contains("Animation"); // File is in an Animation folder
			if (importer.importAnimation)
			{
				importer.animationCompression = ModelImporterAnimationCompression.Optimal;
				importer.animationPositionError = importer.animationRotationError = importer.animationScaleError = 0.1f;
			}
		}
	}

	void OnPreprocessTexture()
	{
		TextureImporter importer = (TextureImporter)assetImporter;

		if (!importer)
			return;

		if (assetPath.Contains("Sprites"))
		{
			importer.textureType = TextureImporterType.Sprite;
			importer.mipmapEnabled = false;
		}
	}
}
