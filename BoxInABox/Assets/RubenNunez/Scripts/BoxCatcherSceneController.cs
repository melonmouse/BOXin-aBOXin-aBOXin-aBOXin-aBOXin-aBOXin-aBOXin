using DG.Tweening;
using TMPro;
using UnityEngine;

namespace RubenNunez.Scripts
{
    public class BoxCatcherSceneController : MonoBehaviour
    {
        [SerializeField]
        private TextMeshPro _warning;
        
        [SerializeField]
        private Transform _blackCurtain;
        
        [SerializeField]
        private Transform _duckyDuck;
        
        [SerializeField]
        private Transform _box;
        
        [SerializeField]
        private Transform _camera;
        
        [SerializeField]
        private Transform _ground;
        
        [SerializeField]
        private CanvasGroup _blackImage;

        private bool _lookAtBox;
        
        public BoxItemState.Item InputItem { private set; get; }
        
        private void Update(){
            if(!_lookAtBox) return;
            var targetRotation = Quaternion.LookRotation(_box.position - _camera.position);
            _camera.rotation = Quaternion.Slerp(_camera.rotation, targetRotation, 2f * Time.deltaTime);
        }

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
            
            _box.gameObject.SetActive(false);
        }

        public void EndSceneAndGotoNext()
        {
            if(_lookAtBox)
                return;

            var animator = _box.GetComponent<Animator>();
            _box.gameObject.SetActive(true);
            _lookAtBox = true;
            
            var sequence = DOTween.Sequence();
            sequence.Insert(0f, _blackCurtain.DOScale(Vector3.one * 100, 0.75f));
            sequence.Insert(0f, _box.parent.DOScale(Vector3.one * 10, 0.75f));
            sequence.Insert(0f, _duckyDuck.DOScale(Vector3.zero , 0.45f));
            sequence.Insert(0f, _ground.DOMove(Vector3.down * 100f, 0.45f));
            sequence.Insert(0f, _blackImage.DOFade(1, 1f));
            sequence.OnStart(() =>
            {
                animator.Play("box-open-anim");
            });
            
            sequence.onComplete += SceneTransition.GoToRandomNextScene;
        }
    }
}