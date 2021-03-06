﻿using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenu;
    public MouseLook mouseLook;
    public GameObject textHolder;
    public GameObject inputField;

    private void Awake()
    {
        mouseLook = FindObjectOfType<MouseLook>();
        textHolder.GetComponent<Text>().text = mouseLook.getSensitivity().ToString();
    }
    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        AudioManager.instance.Play("click");
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        mouseLook.enabled = true;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        mouseLook.enabled = false;
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        // mouse cursor
        GameIsPaused = true;
    } 

    public void titleScreen()
    {
        AudioManager.instance.Play("click");
        StartCoroutine(titleRoutine());
    }

    public void Quit()
    {
        StartCoroutine(quitRoutine());
    }

    IEnumerator titleRoutine()
    {
        yield return new WaitForSecondsRealtime(0.2f);
        GameIsPaused = false;
        SceneManager.LoadSceneAsync("StartScreen");
        Time.timeScale = 1f;
    }

    IEnumerator quitRoutine()
    {
        AudioManager.instance.Play("click");
        yield return new WaitForSecondsRealtime(0.1f);
        AudioManager.instance.Play("wdnmlgb");
        yield return new WaitForSecondsRealtime(2.1f);
        Application.Quit();
    }

    public void Apply()
    {
        AudioManager.instance.Play("apply");
        float sensitivity = mouseLook.getSensitivity();
        try {
            sensitivity = float.Parse(inputField.GetComponent<Text>().text);
        }
        catch (FormatException)
        {

        }
        catch (ArgumentNullException)
        {

        }
        mouseLook.setSensitivity(sensitivity);
        textHolder.GetComponent<Text>().text = sensitivity.ToString();
    }
}
