using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Architecture
{
    public class Cell : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private Renderer meshRenderer;

        public void SetPositionCell(Vector2 position)
        {
            transform.position = new Vector3(position.x, 0, position.y);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            transform.DOMoveY(2, 0.1f);
        }

        private void OnMouseEnter()
        {
            meshRenderer.material.color= Color.cyan;
        }

        private void OnMouseExit()
        {
            meshRenderer.material.color= Color.white;

        }
    }
}