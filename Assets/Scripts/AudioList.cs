
using System.Collections.Generic;
using UnityEngine;

public class AudioList : MonoBehaviour
{
    public List<AudioClip> correctAnswer; //Oyuncu doğru cevabı seçtiği zaman çalacak ses listesi

    public List<AudioClip> wrongAnswer; //Oyuncu yanlış cevabı seçtiği zaman çalacak ses listesi

    public List<AudioClip> correctShape; //Level için hangi şeklin doğru olduğunu belirtecek ses listesi

    public List<AudioClip> correctColor; //Level için hangi rengin doğru olduğunu belirtecek ses listesi

    public List<AudioClip> definitionOfCorrectAnswer; //Levelde hangi renkteki şekli bulacağını belirtecek ses listesi

    public List<AudioClip> startOfLevel; //Seviyenin başlangıcında oynayacak ses listesi

    public List<AudioClip> definitionOfShape; //Şekillerin tanımı

    public AudioClip endOfLevel; //Level sonunda çalınacak ses klibi

    public AudioClip endOfGame; //Oyun bitirilince çalışacak ses klibi
}
