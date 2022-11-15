# ADVEditor

UnityでADVパートを作成する雛形を作成中です。
現在は簡易版につき、このプロジェクト内でのみ使える感じです。

## 使い方

1. Assets/以下の任意のフォルダに素材を用意してInspecterでAdressableにチェックを入れて、任意のパスを設定する
2. 同様に任意の場所にTextAssetいなるファイルを用意してInspecterでAdressableにチェックを入れて任意のパスを設定する
3. ADV/Scripts/ADVPresenterのTestScenario()メソッド内のscenario createの引数に2.のパスを入れる
4. 2.のファイルにシナリオスクリプトを書く。記法はSampleResources/TextSources/を参考, この中のaddressは1.で設定したパスにする
5. 実行する

 参考 : (Assets/ADV/SampleResources)AudioSources, Sprites, TextSources
