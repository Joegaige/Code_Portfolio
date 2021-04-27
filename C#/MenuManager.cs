using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;
using System.Linq;
using UnityEngine.Video;

namespace Interactive360
{

    public class MenuManager : MonoBehaviour
    {

        public Button[] m_buttonsInScene; //A reference to all the buttons in the scene that would load new scenes
        public GameObject m_playButton; //A reference to the button that toggles the video content to play
        public GameObject m_pauseButton;

        private static UnityAction<bool> onHasController = null;

        private static UnityAction onTriggerUp = null;
        private static UnityAction onTriggerDown = null;
        private static UnityAction onTouchpadUp = null;
        private static UnityAction onTouchpadDown = null;

        private bool hasController = false;
        private bool inputActive = true;

        VideoPlayer video;

        void Start()
        {
            DontDestroyOnLoad(gameObject);
            if (FindObjectsOfType(GetType()).Length > 1)
            {
                Destroy(gameObject);
            }
            BindButtonsToScenes();
        }


        //Toggle between showing play and pause button when once is pressed
        public void toggleButton()
        { 
                m_pauseButton.SetActive(!m_pauseButton.activeInHierarchy);
                m_playButton.SetActive(!m_playButton.activeInHierarchy);

        }


        // Each button will match up to a respective scene. Button 1 in the Menu Manager will match up to Scene 1 in the Video Manager
        public void BindButtonsToScenes()
        {
            //check to see if there are the same buttons in the menu as scenes to load. if not, return an error

            if (m_buttonsInScene.Length != GameManager.instance.scenesToLoad.Length)
            {
                Debug.Log("Amount of buttons and scenes do not match!");
                return;
            }

            //otherwise bind Button 1-i from Menu Manager, to load Scene 1-i in Video Manager 
            else
            {
                for (int i = 0; i < m_buttonsInScene.Length; i++)
                {
                    string sceneName = GameManager.instance.scenesToLoad[i];
                    m_buttonsInScene[i].onClick.AddListener(() => GameManager.instance.SelectScene(sceneName));

                }
            }

        }
    }
        
    

}

