using System;
using TMPro;
using UnityEngine.UI;

namespace Core
{
    [Serializable]
    public class UIModel
    {
        public TextMeshProUGUI score, highScore;
        public Button playButton, retryButton;
        public RawImage gameOverImage;
    }
}