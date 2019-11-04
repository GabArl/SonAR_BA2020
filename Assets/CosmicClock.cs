﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CosmicClock : MonoBehaviour
{
	private int sec, min, hour;
	private string day;

	private GameObject anchorSec, anchorMin, anchorHour;
	private GameObject objSec, objMin, objHour;

	public Mesh mesh;

	public int Second
	{
		get
		{
			return sec;
		}

		set
		{
			if (sec == value)
				return;
			sec = value;
			ClockSecond();
			//sec.text = "Damage: " + sec;
		}
	}
	public int Minute
	{
		get
		{
			return min;
		}

		set
		{
			if (min == value)
				return;
			min = value;
			ClockMinute();
		}
	}
	public int Hour
	{
		get
		{
			return hour;
		}

		set
		{
			if (hour == value)
				return;
			hour = value;
			ClockHour();
		}
	}

	// Start is called before the first frame update
	void Start()
	{
		CreateClock();
	}

	[ContextMenu("Create Clock")]
	public void CreateClock()
	{
		anchorSec = new GameObject();
		anchorSec.transform.SetParent(transform);
		anchorSec.name = "anchorSec";
		objSec = new GameObject();
		objSec.transform.SetParent(anchorSec.transform);
		objSec.transform.localPosition = new Vector3(2f, 0f, 0f);
		objSec.name = "objSec";
		objSec.AddComponent<MeshRenderer>();
		objSec.AddComponent<MeshFilter>();
		objSec.GetComponent<MeshFilter>().mesh = mesh;

		anchorMin = new GameObject();
		anchorMin.transform.SetParent(transform);
		anchorMin.name = "anchorMin";
		objMin = new GameObject();
		objMin.transform.SetParent(anchorMin.transform);
		objMin.transform.localPosition = new Vector3(2f, 0f, 0f);
		objMin.name = "objMin";
		objMin.AddComponent<MeshRenderer>();
		objMin.AddComponent<MeshFilter>();
		objMin.GetComponent<MeshFilter>().mesh = mesh;

		anchorHour = new GameObject();
		anchorHour.transform.SetParent(transform);
		anchorHour.name = "anchorHour";
		objHour = new GameObject();
		objHour.transform.SetParent(anchorHour.transform);
		objHour.transform.localPosition = new Vector3(2f, 0f, 0f);
		objHour.name = "objHour";
		objHour.AddComponent<MeshRenderer>();
		objHour.AddComponent<MeshFilter>();
		objHour.GetComponent<MeshFilter>().mesh = mesh;
	}

	private void ClockSecond()
	{
		anchorSec.transform.rotation = Quaternion.Euler(new Vector3(-50, Second * 6, 0));
	}
	private void ClockMinute()
	{
		anchorMin.transform.rotation = Quaternion.Euler(new Vector3(-40, Minute * 6, 0));
	}
	private void ClockHour()
	{
		anchorHour.transform.rotation = Quaternion.Euler(new Vector3(-30, Hour * 6, 0));
	}

	// Update is called once per frame
	void Update()
	{
		if (anchorSec == null) return;
		else Second = System.DateTime.UtcNow.Second;
		if (anchorMin == null) return;
		else Minute = System.DateTime.UtcNow.Minute;
		if (anchorHour == null) return;
		else Hour = System.DateTime.UtcNow.Hour;
		//if (anchorDay == null) return;
		day = System.DateTime.UtcNow.DayOfWeek.ToString();

		Debug.LogWarning("s: " + Second + "   m: " + min + "   h: " + hour + "   d: " + day + "   dow: " + System.DateTime.UtcNow.DayOfWeek);
	}
}
