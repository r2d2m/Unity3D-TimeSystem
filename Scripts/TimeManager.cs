using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour {

	[Tooltip ("How many real life minutes do you want an in-game day to last.")]
	public int minutesPerGameDay = 20;
	[System.NonSerialized]
	public int secondsPerGameDay; // How many real life seconds will an in-game day last.
	public float currentTime;
	[System.NonSerialized]
	public float sunVelocity;

	private float minutesPerSecond; // How many in-game minutes do you want a second to count for. 
	
	// TIME MANAGER: 0.0 equals 6 a.m. 
	// 0.5 equals 6 p.m.
	// this is, a value of 0.5 is a value of 12 hours.
	// 1.0 is 6 a.m of the second day.
	// 4.5 is 6 p.m. of the fourth day.

  // HOW DOES THIS WORK:
  
  // A whole day has 1440 minutes. 
  // According to how many minutes we want a real second to be in our in-game time, we must set a minutes per second value.
  // This value is funcional when sx/1440 = 1, where s is real time seconds and x is minutes per seconde.
  // If we wanted our game to last 20 minutes, the function would be:
  // 1200*z/1440 = 1. If we clear the incognito, we have z = 1,2. Then one real life second would be 1,2 in-game minutes.
  // The script handles this information and delivers it to the sun, to make him rotate at a correct speed.
  // Your sun will make half of its rotation at time 0.5, and full rotation on 1, and so on. Time and sun match
  // perfectly. 
  
  // THE BEAUTY OF IT:
  
  // The beauty of this time system is that it manages time in a very simple way:
  // it doesn't handle hours, but floats.
  // 0.0 means the hour your game begins.
  // 0.5 means 12 hours later.
  // 1.0 means 24 hours later.
  // 2.0 means 48 hours later,
  // and 2.5 means 60 hours later.
  // As you see, we can use the left-side integer to keep track of the days,
  // and the right side decimal to keep track of the time. Cool!
  // So if your game began at 6 a.m., 0.0 means 6 a.m. of the day 1,
  // and 3.5 means 6 p.m. of the day three. So simple! <3
  
  // Another beauty is: time handles the sun, and not vice versa. This is valuable for any game for hundreds of reasons.


	void Start () {
		secondsPerGameDay = minutesPerGameDay * 60;
		minutesPerSecond = 1440f / secondsPerGameDay;
		sunVelocity = (360f / secondsPerGameDay);
	}
	
	void Update () {
		currentTime = Time.time * minutesPerSecond / 1440f;
	}

	public float GetDaysPassed () {
		return Mathf.Floor (currentTime);
	}

	public float GetCurrentTime () {
		return currentTime - GetDaysPassed ();
	}
}
