using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

[Serializable]
[AddComponentMenu("UI/Thai Text", 10)]
public class ThaiTextBreak : MonoBehaviour
{
    private readonly Char SEPARATOR = '\u200B';
    private readonly Char NEWLINE = '\u000A';
    private readonly Char SPACE = '\u0020';
    private readonly Char SPECIAL_TAG = '\uFFF0';
    private readonly Char APPEND_NEWLINE = '\n';

    [SerializeField]
    private float boxwidth;

    [SerializeField]
    RectTransform rect;

    [SerializeField]
    Text textShow;

    [SerializeField]
    TextMeshProUGUI textMeshShow;

    [TextArea]
    public string DefaultText;

    public FontData _fontData;
    private void Awake()
    {
        rect = GetComponent<RectTransform>();
    }
    private void Start()
    {
       
        boxwidth = GetBoxWidth();
        setTextUI(TextAdjust(DefaultText, boxwidth, _fontData));
    }

    void setTextUI(string textAdjust)
    {
        textShow.text = textAdjust;
        textMeshShow.text = textAdjust;
    }

    public float GetBoxWidth()
    {

        float boxwidth = rect.rect.width;
        if (boxwidth <= 0)
        {
            Vector3[] corners = new Vector3[4];
            rect.GetWorldCorners(corners);
            boxwidth = Vector3.Distance(corners[0], corners[3]);
        }
        return boxwidth;
    }

    public string TextAdjust(string value, float boxwidth, FontData fontData)
    {
        value = value.Replace("\\n", "\n");
        string ret = value;
        if (ThaiFontAdjuster.IsThaiString(value))
        {

            ret = ThaiWrappingText(ret, boxwidth, fontData);

            ret = ThaiFontAdjuster.Adjust(ret);
        }
        ret = System.Text.RegularExpressions.Regex.Unescape(ret);
        return ret;
    }

    private string ThaiWrappingText(string value, float boxwidth, FontData fontData)
    {
        List<string> htmlTag;
        string inputText = ParserTag(value, out htmlTag);
        inputText = Lexto.LexTo.Instance.InsertLineBreaks(inputText, SEPARATOR);
        char[] arr = inputText.ToCharArray();
        Font font = fontData.font;
        CharacterInfo characterInfo = new CharacterInfo();
        if (font != null)
        {
            font.RequestCharactersInTexture(inputText, fontData.fontSize, fontData.fontStyle);
        }
        string outputText = "";
        int lineLength = 0;
        string word = "";
        int wordLength = 0;
        int SEPARATOR_Count = 0;
        foreach (char c in arr)
        {
            if (c == SEPARATOR)
            {
                outputText = AddWordToText(outputText, lineLength, word, wordLength, boxwidth, out lineLength);
                word = "";
                wordLength = 0;
                SEPARATOR_Count++;
                continue;
            }
            else if (c == NEWLINE)
            {
                outputText = AddNewLineToText(outputText, lineLength, word, wordLength, boxwidth, out lineLength);
                word = "";
                wordLength = 0;
                continue;
            }
            else if (font != null && font.GetCharacterInfo(c, out characterInfo, fontData.fontSize))
            {
                if (c == SPACE)
                {
                    outputText = AddSpaceToText(outputText, lineLength, word, wordLength, characterInfo.advance, boxwidth, out lineLength);
                    word = "";
                    wordLength = 0;
                }
                else if (c == SPECIAL_TAG)
                {
                    outputText = AddWordToText(outputText, lineLength, word, wordLength, boxwidth, out lineLength);
                    word = "";
                    wordLength = 0;
                    outputText += htmlTag[0];
                    htmlTag.RemoveAt(0);
                }
                else
                {
                    word += c;
                    wordLength += characterInfo.advance;
                }
            }
        }
        outputText = AddWordToText(outputText, lineLength, word, wordLength, boxwidth, out lineLength); // Add remaining word
        return outputText;
    }


    private string ParserTag(string value, out List<string> htmlTag)
    {
        TagString[] tagArr = TagStringParser.Parser(value);
        string parserValue = "";
        htmlTag = new List<string>();
        foreach (TagString tag in tagArr)
        {
            if (tag.IsTag)
            {
                parserValue += SPECIAL_TAG;
                htmlTag.Add(tag.GetTagString());
            }
            else
            {
                parserValue += tag.GetTagString();
            }
        }
        return parserValue;
    }

    private string AddSpaceToText(string inputText, int lineLength, string word, int wordLength, int spaceWidth, float boxwidth, out int totalLength)
    {
        string outputText;
        if (lineLength + wordLength + spaceWidth <= boxwidth)
        {
            outputText = inputText + word + SPACE;
            totalLength = lineLength + wordLength + spaceWidth;
        }
        else if (lineLength + wordLength <= boxwidth)
        {
            outputText = inputText + word + APPEND_NEWLINE;
            totalLength = 0;
        }
        else
        {
            outputText = inputText + APPEND_NEWLINE + word + SPACE;
            totalLength = wordLength + spaceWidth;
        }
        return outputText;
    }

    private string AddWordToText(string inputText, int lineLength, string word, int wordLength, float boxwidth, out int totalLength)
    {
        string outputText;
        if (lineLength + wordLength <= boxwidth)
        {
            outputText = inputText + word;
            totalLength = lineLength + wordLength;
        }
        else
        {
            outputText = inputText + APPEND_NEWLINE + word;
            totalLength = wordLength;
        }
        return outputText;
    }

    private string AddNewLineToText(string inputText, int lineLength, string word, int wordLength, float boxwidth, out int totalLength)
    {
        string outputText;
        if (lineLength + wordLength <= boxwidth)
        {
            outputText = inputText + word + APPEND_NEWLINE;
            totalLength = 0;
        }
        else
        {
            outputText = inputText + APPEND_NEWLINE + word;
            totalLength = wordLength;
        }
        return outputText;
    }

    private void OnRectTransformDimensionsChange()
    {
        if (rect != null)
        {
            float checkWidth = GetBoxWidth();
            if (checkWidth > 0 && (checkWidth != this.boxwidth))
            {
                this.boxwidth = checkWidth;
                setTextUI(TextAdjust(DefaultText, boxwidth, _fontData));
            }
        }
    }
}
