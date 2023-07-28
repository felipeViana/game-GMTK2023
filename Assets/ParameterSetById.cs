using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParametersSetByID : MonoBehaviour
{
    FMOD.Studio.EventInstance Ambience;

    FMOD.Studio.EventDescription AmbienceDescription;
    FMOD.Studio.PARAMETER_DESCRIPTION pd;
    FMOD.Studio.PARAMETER_ID pID;

    private void Start()
    {
        Ambience = FMODUnity.RuntimeManager.CreateInstance("event:/Ambience");
        Ambience.start();

        AmbienceDescription = FMODUnity.RuntimeManager.GetEventDescription("event:/Ambience");
        AmbienceDescription.getParameterDescriptionByName("Ambience Fade", out pd);
        pID = pd.id;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "FPSController")
            Ambience.setParameterByID(pID, 1f);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "FPSController")
            Ambience.setParameterByID(pID, 0f);
    }
}