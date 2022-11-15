using UnityEditor.Experimental.GraphView;
using UnityEditor.UIElements;


public class SampleGraphView : GraphView
{
    public SampleGraphView() : base()
    {
        // 親UIにしたがって拡大縮小を行う設定
        style.flexGrow = 1;
        style.flexShrink = 1;

        SetupZoom(ContentZoomer.DefaultMinScale, ContentZoomer.DefaultMaxScale);

        Insert(0, new GridBackground());

        // this.AddManipulator(new SelectionDragger());

        SetEvents();
    }

    private void SetEvents()
    {
        // SampleGraphViewのメニュー周りのイベントを設定する処理
        nodeCreationRequest += context =>
        {
            // 後述するNodeというクラスのインスタンス生成
            var node = new Node();
            // GraphViewの子要素として追加する
            AddElement(node);
        };

        nodeCreationRequest += sample =>
        {
            var node = new SampleNode();
            AddElement(node);
        };
    }
}