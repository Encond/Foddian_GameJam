using UI;
using UnityEngine;

namespace Items
{
    public class Battery : MonoBehaviour
    {
        [SerializeField] private Timer _timer;
        
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.TryGetComponent(out Player.Player player))
            {
                _timer.ResetTimer();
                Destroy(this.gameObject);
            }
        }
    }
}