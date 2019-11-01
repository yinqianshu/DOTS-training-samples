﻿using System;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

[Serializable]
public struct CarSpawnProperties : IComponentData
{
    public float defaultSpeedMin;
    public float defaultSpeedMax;
    public float overtakeSpeedMin;
    public float overtakeSpeedMax;
    public float overtakeEagernessMin;
    public float overtakeEagernessMax;
    public Color defaultColor;
    public Color slowSpeedColor;
    public Color highSpeedColor;
    public float mergeSpaceMin;
    public float mergeSpaceMax;
    public float mergeLeftDistanceMin;
    public float mergeLeftDistanceMax;
    public float acceleration;
    public float brakeDeceleration;
    public float laneSwitchSpeed;
    public float maxOvertakeTime;
}

[DisallowMultipleComponent]
[RequiresEntityConversion]
public class CarSpawnerComponent : MonoBehaviour, IConvertGameObjectToEntity
{
    // Changing all the names because the compiler gives me too many name collision issues
    public float normalSpeedMin;
    public float normalSpeedMax;
    public float topSpeedMin;
    public float topSpeedMax;
    public float eagernessMin;
    public float eagernessMax;
    public Color normalColor;
    public Color slowColor;
    public Color fastColor;
    public float mergeRoomMin;
    public float mergeRoomMax;
    public float mergeDistanceMin;
    public float mergeDistanceMax;
    public float accel;
    public float brakeDecel;
    public float laneSwitchRate;
    public float maxPassingTime;

    // Convert the MonoBehavior to an Entity
    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        var data = new CarSpawnProperties
        {
            defaultSpeedMin = normalSpeedMin,
            defaultSpeedMax = normalSpeedMax,
            overtakeSpeedMin = topSpeedMin,
            overtakeSpeedMax = topSpeedMax,
            overtakeEagernessMin = eagernessMin,
            overtakeEagernessMax = eagernessMax,
            defaultColor = normalColor,
            slowSpeedColor = slowColor,
            highSpeedColor = fastColor,
            mergeSpaceMin = mergeRoomMin,
            mergeSpaceMax = mergeRoomMax,
            mergeLeftDistanceMin = mergeDistanceMin,
            mergeLeftDistanceMax = mergeDistanceMax,
            acceleration = accel,
            brakeDeceleration = brakeDecel,
            laneSwitchSpeed = laneSwitchRate,
            maxOvertakeTime = maxPassingTime
        };

        dstManager.AddComponentData(entity, data);
    }
}