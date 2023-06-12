using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;
    public static Tree _tree;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void JumpToTree(TreeData tree)
    {
        _tree = new Tree(); // Substitua este código com a forma correta de criar uma instância de Tree
        _tree.SpawnTree();
    }
}

