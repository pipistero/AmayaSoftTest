using System.Threading.Tasks;
using UnityEngine;

namespace Window
{
    public abstract class Window : MonoBehaviour
    {
        [SerializeField] protected GameObject _content;
        
        public abstract Task Open();
        public abstract Task Close();
    }
}