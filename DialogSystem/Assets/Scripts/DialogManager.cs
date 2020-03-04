using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    private Queue<string> Sentences;

    public Text Name;
    public Text DialogText;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        Sentences = new Queue<string>();
    }


    public void StartDialog(Dialog dialog)
    {
        Debug.Log("Start Converstaion with " + dialog.name);

        Sentences.Clear();
        DialogText.text = "";

        animator.SetBool("IsOpen", true);

        Name.text = dialog.name;

        foreach(string sentence in dialog.Sentences)
        {
            Sentences.Enqueue(sentence);
        }

        Invoke("DisplayNextSentence", .3f);
    }

    public void DisplayNextSentence()
    {
        if(Sentences.Count == 0)
        {
            EndDialog();
            return;
        }

        string sentence = Sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        DialogText.text = "";

        foreach (char letter in sentence.ToCharArray())
        {
            DialogText.text += letter;
            yield return new WaitForSeconds(.01f);
        }
    }


    void EndDialog()
    {
        animator.SetBool("IsOpen", false);
    }

}
