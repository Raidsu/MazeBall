using UnityEngine.SceneManagement;

namespace Items
{
    internal sealed class DeadlyItems : Items
    {
        internal override void DoEffect()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            
        }
    }
}