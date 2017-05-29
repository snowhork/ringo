using Script.Characters;
using UniRx;
using UnityEngine;
using Zenject;

namespace Script.UI
{
    public class SpecialUi : MonoBehaviour
    {
        [SerializeField] private Renderer[] _specials;

        [Inject]
        public void Construct(BaseCharacterParameter parameter)
        {
            parameter.OnSpecialWeaponCount.Subscribe(SetSpecial);
        }
        
        private void Start()
        {
            transform.parent = Camera.main.transform;
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
        }

        private void SetSpecial(int sp)
        {
            for (var i = 0; i < _specials.Length; i++)
            {
                _specials[i].GetComponent<MeshRenderer>().enabled = (i < sp);
            }
        }
    }
}
