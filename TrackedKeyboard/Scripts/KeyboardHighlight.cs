using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardHighlight : MonoBehaviour
{
    public GameObject a_Key;
    public GameObject b_Key;
    public GameObject c_Key;
    public GameObject d_Key;
    public GameObject e_Key;
    public GameObject f_Key;
    public GameObject g_Key;
    public GameObject h_Key;
    public GameObject i_Key;
    public GameObject j_Key;
    public GameObject k_Key;    
    public GameObject l_Key;
    public GameObject m_Key;
    public GameObject n_Key;    
    public GameObject o_Key;
    public GameObject p_Key;
    public GameObject q_Key;
    public GameObject r_Key;
    public GameObject s_Key;
    public GameObject t_Key;
    public GameObject u_Key;
    public GameObject v_Key;
    public GameObject w_Key;
    public GameObject x_Key;
    public GameObject y_Key;
    public GameObject z_Key;
    public GameObject enter_Key;
    public GameObject space_Key;

    private GameObject activeKey;

    private void Start()
    {
        activeKey = m_Key;
        m_Key.SetActive(true);
    }
    public void HighlightKey(char letterToHighlight)
    {
        switch (letterToHighlight)
        {
            case 'a':
                activeKey.SetActive(false);
                a_Key.SetActive(true);
                activeKey = a_Key;
                break;
            case 'b':
                activeKey.SetActive(false);
                b_Key.SetActive(true);
                activeKey = b_Key;
                break;
            case 'c':
                activeKey.SetActive(false);
                c_Key.SetActive(true);
                activeKey = c_Key;  
                break;
            case 'd':
                activeKey.SetActive(false);
                d_Key.SetActive(true);
                activeKey = d_Key;
                break;
            case 'e':
                activeKey.SetActive(false);
                e_Key.SetActive(true);
                activeKey = e_Key;
                break;
            case 'f':
                activeKey.SetActive(false);
                f_Key.SetActive(true);
                activeKey = f_Key;
                break;
            case 'g':
                activeKey.SetActive(false);
                g_Key.SetActive(true);
                activeKey = g_Key;
                break;
            case 'h':
                activeKey.SetActive(false);
                h_Key.SetActive(true);
                activeKey = h_Key;
                break;
            case 'i':
                activeKey.SetActive(false);
                i_Key.SetActive(true);
                activeKey = i_Key;
                break;
            case 'j':
                activeKey.SetActive(false);
                j_Key.SetActive(true);
                activeKey = j_Key;
                break;
            case 'k':
                activeKey.SetActive(false);
                k_Key.SetActive(true);
                activeKey = k_Key;
                break;
            case 'l':
                activeKey.SetActive(false);
                l_Key.SetActive(true);
                activeKey = l_Key;
                break;
            case 'm':
                activeKey.SetActive(false);
                m_Key.SetActive(true);
                activeKey = m_Key;  
                break;
            case 'n':
                activeKey.SetActive(false);
                n_Key.SetActive(true);
                activeKey = n_Key;
                break;
            case 'o':
                activeKey.SetActive(false);
                o_Key.SetActive(true);
                activeKey = o_Key;
                break;
            case 'p':
                activeKey.SetActive(false);
                p_Key.SetActive(true);
                activeKey = p_Key;
                break;
            case 'q':
                activeKey.SetActive(false);
                q_Key.SetActive(true);
                activeKey = q_Key;
                break;
            case 'r':
                activeKey.SetActive(false);
                r_Key.SetActive(true);
                activeKey = r_Key;
                break;
            case 's':
                activeKey.SetActive(false);
                s_Key.SetActive(true);
                activeKey = s_Key;
                break;
            case 't':
                activeKey.SetActive(false);
                t_Key.SetActive(true);
                activeKey = t_Key;
                break;
            case 'u':
                activeKey.SetActive(false);
                u_Key.SetActive(true);
                activeKey = u_Key;
                break;
            case 'v':
                activeKey.SetActive(false);
                v_Key.SetActive(true);
                activeKey = v_Key;
                break;
            case 'w':
                activeKey.SetActive(false);
                w_Key.SetActive(true);
                activeKey = w_Key;
                break;
            case 'x':
                activeKey.SetActive(false);
                x_Key.SetActive(true);
                activeKey = x_Key;
                break;
            case 'y':
                activeKey.SetActive(false);
                y_Key.SetActive(true);
                activeKey = y_Key;
                break;
            case 'z':
                activeKey.SetActive(false);
                z_Key.SetActive(true);
                activeKey = z_Key;
                break;
            case '\n':
                activeKey.SetActive(false);
                enter_Key.SetActive(true);
                activeKey = enter_Key;
                break;
            case ' ':
                activeKey.SetActive(false);
                space_Key.SetActive(true);
                activeKey = space_Key;
                break;
            default:
                Debug.Log("No option for " + letterToHighlight);
                break;
        }
    }
    public void TurnOffActive()
    {
        activeKey.SetActive(false);
    }
}
