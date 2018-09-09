# Atlas Manager

## 概要

画像を取得した際などに、リアルタイムに画像をアトラス化して、バッチをかけやすくする。

おもにYoutube Data API v3用

あと、画像サイズ88 x 88推奨

## 使い方

AtlasManager.Instace.AddIconTextureToAtlas(Texture2d)

でAtlasInfoが返ってきます。

AtlasInfoには
atlasId: 画像がいっぱいになるとアトラス画像も増えるので、その管理用
textureId: ほぼ確認用で使わないと思う。
packedTexture: アトラス化されている画像。
UVrect: アトラス画像上の座標情報 RawImageで直接指定出来る。


表示用のマテリアルに返ってきたpackedTextureを設定し、UV情報を渡すだけ。