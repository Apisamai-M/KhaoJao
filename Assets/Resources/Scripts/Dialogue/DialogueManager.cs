using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class DialogueManager : MonoBehaviour
{
   // public Text nameText;
    public Text dialogueText;
    public Animator animator;
    private Queue<string> sentences;

    //use this for initialization

    void Awake()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        animator.SetBool("IsOpen", true);
        animator.SetBool("IsSomgwongStart", true);
       

        //Debug.Log("Starting conversation with " + dialogue.name);

        //nameText.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {

        if (sentences.Count %2 != 0 )
        {
            animator.SetBool("IsKaoJaoStart", true);
            animator.SetBool("IsKaoJaoTalking", true);
        }
        else
        {
            animator.SetBool("IsKaoJaoTalking", false);
        }

        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
       
        //dialogueText.text = sentence;
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));

    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = ""; 
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.02f);
        }
    }

    void EndDialogue()
    {
       
        animator.SetBool("IsOpen", false);
        animator.SetBool("IsKaoJaoStart", false);
        animator.SetBool("IsSomgwongStart", false);

        PlayerPrefs.SetString("HasSeenIntro", "yes");

        SceneManager.LoadScene("Level1Instruction");
    }

}
