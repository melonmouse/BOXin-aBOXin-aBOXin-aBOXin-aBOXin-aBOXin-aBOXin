using TMPro;
using UnityEngine;

namespace RubenNunez.Scripts
{
    public class BoxCatcherSceneController : MonoBehaviour
    {
        [SerializeField]
        private TextMeshPro _warning;
        
        public BoxItemState.Item InputItem { private set; get; }

        private void Start()
        {
            // input Item as Enum
            InputItem = BoxItemState.Instance.HeldItem;
            if (InputItem == BoxItemState.Item.BaseItem)
            {
                // should never be BaseItem
                InputItem = BoxItemState.Item.HourGlass;
            }
            
            _warning.text = _warning.text.Replace("{0}", InputItem.ToString());
        }
    }
}