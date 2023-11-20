using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Elevator : MonoBehaviour
{
    public float speed = 1f;
    public float closeTimer = 10f;
    public List<Vector3> floors;
    public List<DoorStates> doorStates;
    public List<DoubleDoors> doorSets;
    public List<OpenDoor> openDoorLevels;
    public List<CloseDoor> closeDoorLevels;

    public List<DoubleDoors> doorSetsElevator;
    public List<OpenDoor> openDoorElevator;
    public List<CloseDoor> closeDoorElevator;

    public int curFloor;
    public bool isMoving = false;
    
    public void RequestMoveToFloor(int floor)
    {
        if (isMoving || floor == curFloor) return; //

        StartCoroutine(MoveToFloor(floors[floor], floor));
    }

    IEnumerator MoveToFloor(Vector3 targetFloorPos, int floor)
    {
        CloseDoors(curFloor);
        yield return new WaitForSeconds(2);
        isMoving = true;
        curFloor = floor;
        while (transform.localPosition != targetFloorPos) 
        {            
            float step = speed * Time.deltaTime;
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, targetFloorPos, step);
            yield return null;
        }
        OpenDoors(floor);
        yield return new WaitForSeconds(2);
        isMoving = false;        
    }

    public void OpenDoors(int floor)
    {
        if (doorStates[floor].frontDoorOpen)//elevator
        {
            openDoorElevator[0].openFrontDoorL.Invoke();
            openDoorElevator[0].openFrontDoorR.Invoke();
        }
        if (doorStates[floor].backDoorOpen)//elevator
        {
            openDoorElevator[0].openBackDoorL.Invoke();
            openDoorElevator[0].openBackDoorR.Invoke();
        }

        if (doorStates[floor].frontDoorOpen)
        {
            openDoorLevels[floor].openFrontDoorL.Invoke();
            openDoorLevels[floor].openFrontDoorR.Invoke();
        }        
        if (doorStates[floor].backDoorOpen)
        {
            openDoorLevels[floor].openBackDoorL.Invoke();
            openDoorLevels[floor].openBackDoorR.Invoke();
        }
    }

    public void CloseDoors(int floor)
    {        
        if (doorStates[floor].frontDoorOpen)//elevator
        {
            closeDoorElevator[0].closeFrontDoorL.Invoke();
            closeDoorElevator[0].closeFrontDoorR.Invoke();
        }
        if (doorStates[floor].backDoorOpen)//elevator
        {
            closeDoorElevator[0].closeBackDoorL.Invoke();
            closeDoorElevator[0].closeBackDoorR.Invoke();
        }

        if (doorStates[floor].frontDoorOpen)
        {
            closeDoorLevels[floor].closeFrontDoorL.Invoke();
            closeDoorLevels[floor].closeFrontDoorR.Invoke();
        }
        if (doorStates[floor].backDoorOpen)
        {
            closeDoorLevels[floor].closeBackDoorL.Invoke();
            closeDoorLevels[floor].closeBackDoorR.Invoke();
        }
    }

    [Serializable]
    public struct DoorStates
    {
        public bool frontDoorOpen;
        public bool backDoorOpen;

        public DoorStates(bool frontDoorOpen = true, bool backDoorOpen = true)
        {
            this.frontDoorOpen = true;
            this.backDoorOpen = true;
        }
    }

    [Serializable]
    public struct DoubleDoors
    {
        public GameObject frontLeftDoor;
        public GameObject frontRightDoor;

        public GameObject backLeftDoor;
        public GameObject backRightDoor;

        public DoubleDoors(GameObject frontLeftDoor, GameObject frontRightDoor, GameObject backLeftDoor, GameObject backRightDoor)
        {
            this.frontLeftDoor = frontLeftDoor;
            this.frontRightDoor = frontRightDoor;
            this.backLeftDoor = backLeftDoor;
            this.backRightDoor = backRightDoor;
        }
    }

    [Serializable]
    public struct OpenDoor
    {
        public UnityEvent openFrontDoorL;
        public UnityEvent openFrontDoorR;
        public UnityEvent openBackDoorL;
        public UnityEvent openBackDoorR;
    }

    [Serializable]
    public struct CloseDoor
    {
        public UnityEvent closeFrontDoorL;
        public UnityEvent closeFrontDoorR;
        public UnityEvent closeBackDoorL;
        public UnityEvent closeBackDoorR;
    }
}
