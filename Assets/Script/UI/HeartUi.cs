using UnityEngine;
using Zenject;

namespace Script.UI
{
    public class HeartUi : MonoBehaviour
    {
        [SerializeField] private Renderer[] _hearts;

        private void Start()
        {
            transform.parent = Camera.main.transform;
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
            SetHeart(3);
        }

        public void SetHeart(int hp)
        {

            for (var i = 0; i < _hearts.Length; i++)
            {
                _hearts[i].GetComponent<MeshRenderer>().enabled = (i < hp);
            }
        }
    }
}
