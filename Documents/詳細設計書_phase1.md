# Phase 1 詳細設計書
対象：盤面生成〜単マス配置まで（戦闘ロジック未実装段階）

---

# 1. Phase1の目的

## 到達目標

- 三角グリッド（25マス）が正しく生成される
- 各マスがクリック可能
- 単マスカードを任意の空きマスへ配置できる
- 占有状態が正しく管理される
- 視覚的に「置けた」ことが分かる

まだやらないもの：

- ライン判定
- ダメージ処理
- 敵ターン
- 勝敗判定

---

# 2. 実装スコープ

## 実装対象クラス

Core
- BoardManager
- Cell
- CellCoordinateUtility

Card
- CardData（ScriptableObject）
- CardInstance
- CardManager

UI
- CellView
- HandView
- CardView
- UIController（最低限）

Game
- GameManager（初期化のみ）

---

# 3. 三角グリッド仕様

## 3.1 前提

- 正三角形タイル
- 合計24マス
- 3方向の直線構造を持つ

## 3.2 座標設計

Phase1では **Axial座標簡易版** を採用。

```
Vector2Int(x, y)
```


制約：

```
|x| + |y| + |(-x - y)| <= 4
```


※ 半径2相当の六角構造を三角化した内部24セル

※ 将来的にCube座標へ拡張可能

---

# 4. BoardManager 詳細設計

## 4.1 責務

- 盤面生成
- セル管理
- 配置可否判定
- セル状態更新

---

## 4.2 フィールド

```
Dictionary<Vector2Int, Cell> cells
GameObject cellPrefab
Transform boardRoot
```


---

## 4.3 メソッド設計

### Initialize()

- 座標リスト生成
- 各座標にCell生成
- CellView生成

---

### GenerateCoordinates()

返却：

```
List<Vector2Int>
```


処理：

- 制約式を満たす座標を全探索生成

---

### CanPlace(Vector2Int coord)

条件：

```
cells.ContainsKey(coord)
&& !cells[coord].isOccupied
```


---

### PlaceCard(Vector2Int coord, CardInstance card)

処理：

1. CanPlaceチェック
2. cells[coord].isOccupied = true
3. cells[coord].placedCard = card
4. CellViewへ通知

---

# 5. Cell 設計

## 5.1 責務

- 単一マスの状態保持

## 5.2 フィールド

```
Vector2Int coordinate
bool isOccupied
CardInstance placedCard
```


ロジックは持たない（データのみ）

---

# 6. Cardシステム（Phase1簡易版）

## 6.1 CardData

ScriptableObject

```
string cardName
Sprite icon
int power（未使用）
```


---

## 6.2 CardInstance

```
CardData data
```


将来：

- 強化値
- 一時バフ
- コスト

を追加可能

---

# 7. CardManager 設計

## 7.1 責務

- 手札生成
- 現在選択中カード管理

---

## 7.2 フィールド

```
List<CardInstance> hand
CardInstance selectedCard
```


---

## 7.3 メソッド

### Initialize()

- 仮カード3枚生成

---

### SelectCard(CardInstance card)

- selectedCard = card

---

### UseSelectedCard(Vector2Int coord)

1. BoardManager.CanPlace確認
2. BoardManager.PlaceCard実行
3. 手札から削除
4. selectedCard = null

---

# 8. UI設計（Phase1最小構成）

---

# 8.1 CellView

## 責務

- マス表示
- クリック受付
- 占有状態の可視化

## フィールド

```
Vector2Int coordinate
BoardManager boardManager
SpriteRenderer renderer
```


## OnMouseDown()

```
CardManager.UseSelectedCard(coordinate)
```


---

# 8.2 CardView

## 責務

- カード表示
- 選択処理

## OnClick()

CardManager.SelectCard(this.cardInstance)


---

# 8.3 HandView

- CardManager.handを元にUI再生成
- Refresh()で再描画

---

# 9. 初期化フロー

```
GameManager.Start()

↓
BoardManager.Initialize()
↓
CardManager.Initialize()
↓
UIController.Initialize()
```


---

# 10. プレイヤー操作フロー

1. CardViewクリック
2. selectedCard設定
3. Cellクリック
4. CanPlace判定
5. 配置成功
6. マスの色変更

---

# 11. エラーハンドリング

## 置けない場合

- 何もしない
- 軽いログ出力

将来的に：

- 揺れアニメーション
- 赤点滅

---

# 12. テストチェックリスト

## 盤面

- 24マス生成される
- 重複なし
- 配置座標が正しい

## 配置

- 空きマスに置ける
- 既存マスには置けない
- 手札から消える

## UI

- カード選択時に視覚変化
- マス占有時に色変化

---

# 13. 完了定義（Definition of Done）

以下が満たされたらPhase1完了：

- ゲーム起動で盤面表示
- 手札3枚表示
- カード選択可能
- マスへ単マスカード配置可能
- 二重配置不可

---

# 14. 技術的注意点

- Viewはロジックを持たない
- 盤面状態はBoardManagerのみが保持
- CardManagerはBoardManagerへ依存する
- 依存方向は一方向に保つ

---

# 15. 実装順序（推奨）

1. Cellクラス作成
2. BoardManagerで座標生成
3. CellViewプレハブ作成
4. 盤面表示確認
5. CardData作成
6. CardManager作成
7. CardView作成
8. 配置連携

---

# 16. Phase1成果物

- 三角グリッドが生成されるUnityシーン
- 単マス配置可能な最低限の動作確認版

---

# Phase1の思想

目的は：

> 「盤面が触れる」状態を作ること

戦闘でもローグライトでもない。

触れる盤面を作る。

それが基盤。
