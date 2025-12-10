using UnityEngine;

public enum ZoneTypes
{
    TaxiZone,
    HospitalZone,
    MouthZone
}

public class ZoneType : MonoBehaviour
{
    [SerializeField] private ZoneTypes type;

    public ZoneTypes Type { get { return type; } }
}
