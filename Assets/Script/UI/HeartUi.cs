using Script.Characters;
using UnityEngine;
using Zenject;
using UniRx;

namespace Script.UI
{
    public class HeartUi : MonoBehaviour
    {
        [SerializeField] private Renderer[] _hearts;

        [Inject]
        public void Construct(BaseCharacterParameter parameter)
        {
            parameter.OnHpChanged.Subscribe(SetHeart);
        }
        
        private void Start()
        {
            transform.parent = Camera.main.transform;
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
            SetHeart(1);
        }

        private void SetHeart(int hp)
        {

            for (var i = 0; i < _hearts.Length; i++)
            {
                _hearts[i].GetComponent<MeshRenderer>().enabled = (i < hp);
            }
        }
    }
}
