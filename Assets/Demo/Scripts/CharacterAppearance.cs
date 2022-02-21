using FishNet.Object;
using UnityEngine;

public class CharacterAppearance : NetworkBehaviour
{
    [SerializeField]
    private Material m_playerMat;
    [SerializeField]
    private Material m_opponentMat;

    [SerializeField]
    private MeshRenderer m_MeshRenderer;

    public override void OnStartClient()
    {
        //base.OnStartClient();
        m_MeshRenderer.material = base.IsOwner ? m_playerMat : m_opponentMat;

        if (!base.IsOwner)
        {
            transform.position = Vector3.Reflect(transform.position, Vector3.forward);
        }
    }

}
