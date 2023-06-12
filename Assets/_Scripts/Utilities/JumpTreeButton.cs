using UnityEngine;

public class JumpTreeButton : MonoBehaviour
{
    public Tree tree;

    private void Start()
    {
        // Certifique-se de que o objeto TreeManager esteja atribuído no Inspector
    }

    public void OnJumpButtonClicked()
    {
        tree.SpawnTree();
    }
}
