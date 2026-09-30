MakeAFont -> Unity
font: MakeAFont-20260928-1524

Unity has no built-in AngelCode .fnt importer, so this bundle ships one.

1. Copy the whole folder into Assets/ somewhere in your project.
2. Unity compiles Editor/BitmapFontImporter.cs automatically.
3. Menu: Tools > MakeAFont > Build Font From .fnt
   Pick font.fnt when asked. It writes font.asset (a Font) and font.mat beside it.
4. Assign font.asset to a UI Text, or use it with TextMesh.

Notes
- The importer sets the texture to Point filter and no compression, which is what
  pixel-art fonts need; it does that for you on import.
- font.json carries the same glyph table if you would rather drive your own pipeline.
- This builds a legacy Font asset. TextMeshPro needs its own asset; you can generate
  one from this Font with TMP's Font Asset Creator if you use TMP.