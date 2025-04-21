using UnityEngine;
using Sirenix.OdinInspector;
using TMPro;

public class GameManager : MonoBehaviour
{
    #region Properties
    private Stack<Movement> movementStack = new Stack<Movement>();

    [Header("UI")]
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private Sprite walkSprite;
    [SerializeField] private Sprite jumpSprite;
    [SerializeField] private Sprite attackSprite;
    [SerializeField] private SpriteRenderer myspriteRenderer;
    #endregion
    void Start()
    {
        PlayerWalk();
        ReadMovement();
    }
    #region UpdateUI
    public Movement SetMovement(string name)
    {
        return new Movement(name);
    }
    public void SetNameText(string name)
    {
        nameText.text = name;
    }

    [Button("Read Current Movement")]
    public void ReadMovement()
    {
        if (movementStack.Count == 0)
        {
            Debug.Log("No quedan mas movimientos en la pila");
            nameText.text = "No quedan mas movimientos en la pila";
            myspriteRenderer.sprite = null;
            return;
        }

        Debug.Log(movementStack.Peek().MovementName);
        nameText.text = movementStack.Peek().MovementName;
        myspriteRenderer.sprite = movementStack.Peek().MovementName switch
        {
            "Walk" => walkSprite,
            "Jump" => jumpSprite,
            "Attack" => attackSprite,
            _ => null
        };
    }

    [Button("Return Movement")]
    public void ReturnMovement()
    {
        movementStack.Pop();
        ReadMovement();
    }
    #endregion

    #region Movements
    [Button("Walk")]
    public void PlayerWalk()
    {
        Movement movement = SetMovement("Walk");
        movementStack.Push(movement);
        SetNameText(movement.MovementName);
        myspriteRenderer.sprite = walkSprite;
    }

    [Button("Jump")]
    public void PlayerJump()
    {
        Movement movement = SetMovement("Jump");
        movementStack.Push(movement);
        SetNameText(movement.MovementName);
        myspriteRenderer.sprite = jumpSprite;
    }

    [Button("Attack")]
    public void PlayerAttack()
    {
        Movement movement = SetMovement("Attack");
        movementStack.Push(movement);
        SetNameText(movement.MovementName);
        myspriteRenderer.sprite = attackSprite;
    }
    #endregion
}

