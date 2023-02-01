using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    [RequireComponent(typeof(Button))]
    public abstract class AbstractButtonView : MonoBehaviour
    {
        private Button _button = default;

        protected void Awake()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(OnButtonClick);
        }

        protected void OnDestroy() => 
            _button.onClick.RemoveListener(OnButtonClick);

        protected abstract void OnButtonClick();
    }
}
