using UnityEngine;

namespace GameToolsSystem
{
    public class GameToolsData_base : ScriptableObject
    {
        [TextArea(2, 500)]
        [SerializeField] private string _info;
    }
}