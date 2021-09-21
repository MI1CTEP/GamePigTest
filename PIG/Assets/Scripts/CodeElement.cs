using UnityEngine;

public class CodeElement : MonoBehaviour
{
    public int _idElement;

    [SerializeField] private InstallationBomb _installationBomb;

    public void ClickToCodeElement()
    {
        _installationBomb.ActiveCodeElement(_idElement);
    }
}
