using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class InstallationBomb : MonoBehaviour
{
    public Transform _bomb;

    [SerializeField] private GameObject _activationPanel;
    [SerializeField] private Button[] _codeElement;

    private Color[] _color = { Color.blue, Color.red, Color.green, Color.yellow };
    private int[] _randomArray;
    private int _valueActive;
    private int _nomberOfClicks;
    private int _idElement = -1;

    public void ActivateBomb()
    {
        _randomArray = RandomArray();
        _activationPanel.SetActive(true);
    }

    private void bombIsActivated()
    {
        _bomb.position = new Vector3(transform.position.x, 0, transform.position.z);
        Instantiate(_bomb);
    }

    public void ActiveCodeElement(int idElement)
    {
        _codeElement[idElement].interactable = false;
        _codeElement[idElement].GetComponent<Image>().color = _color[_randomArray[idElement]];
        _nomberOfClicks++;

        if (_nomberOfClicks == 2)
        {
            if (_randomArray[_idElement] == _randomArray[idElement])
                _valueActive++;
            else
                StartCoroutine(TimeLook(idElement));
            _nomberOfClicks = 0;
        }
        else
            _idElement = idElement;
        if(_valueActive == 4)
        {
            bombIsActivated();
            ResetActivated();
        }
    }

    public void ResetActivated()
    {
        _valueActive = 0;
        _activationPanel.SetActive(false);
        for (int i = 0; i < _codeElement.Length; i++)
        {
            _codeElement[i].interactable = true;
            _codeElement[i].GetComponent<Image>().color = Color.white;
        }
    }

    private IEnumerator TimeLook(int idElement)
    {
        yield return new WaitForSeconds(0.3f);
        _codeElement[idElement].interactable = true;
        _codeElement[_idElement].interactable = true;
        _codeElement[idElement].GetComponent<Image>().color = Color.white;
        _codeElement[_idElement].GetComponent<Image>().color = Color.white;
    }

    private int[] RandomArray()
    {
        int[] array = { 0, 0, 1, 1, 2, 2, 3, 3 };
        for (int i = 0; i < array.Length; i++)
        {
            int tmp = array[i];
            int r = Random.Range(i, array.Length);
            array[i] = array[r];
            array[r] = tmp;
        }
        return array;
    }
}
