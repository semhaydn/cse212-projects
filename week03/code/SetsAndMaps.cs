using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Diagnostics;
using System.Net.Http;

public static class SetsAndMaps
{
    /// <summary>
    /// The words parameter contains a list of two character 
    /// words (lower case, no duplicates). Using sets, find an O(n) 
    /// solution for returning all symmetric pairs of words.  
    ///
    /// For example, if words was: [am, at, ma, if, fi], we would return :
    ///
    /// ["am & ma", "if & fi"]
    ///
    /// The order of the array does not matter, nor does the order of the specific words in each string in the array.
    /// at would not be returned because ta is not in the list of words.
    ///
    /// As a special case, if the letters are the same (example: 'aa') then
    /// it would not match anything else (remember the assumption above
    /// that there were no duplicates) and therefore should not be returned.
    /// </summary>
    /// <param name="words">An array of 2-character words (lowercase, no duplicates)</param>
        public static string[] FindPairs(string[] words)
    {
        var wordSet = new HashSet<string>(words);
        var pairs = new List<string>();

        foreach (var word in words)
        {
            // Skip if both characters are the same (e.g., "aa")
            if (word[0] == word[1])
                continue;

            // Compute the reversed word
            string reversed = new string(new char[] { word[1], word[0] });

            // To avoid duplicate pairs, only add when word is lexicographically smaller than its reverse.
            if (string.Compare(word, reversed) < 0 && wordSet.Contains(reversed))
            {
                pairs.Add($"{reversed} & {word}");
            }
        }
        return pairs.ToArray();
    }

    /// <summary>
    /// Read a census file and summarize the degrees (education)
    /// earned by those contained in the file.  The summary
    /// should be stored in a dictionary where the key is the
    /// degree earned and the value is the number of people that 
    /// have earned that degree.  The degree information is in
    /// the 4th column of the file.  There is no header row in the
    /// file.
    /// </summary>
    /// <param name="filename">The name of the file to read</param>
    /// <returns>fixed array of divisors</returns>
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();
        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(",");
            if (fields.Length >= 4)
            {
                string degree = fields[3].Trim();
                if (degrees.ContainsKey(degree))
                    degrees[degree]++;
                else
                    degrees[degree] = 1;
            }
        }
        return degrees;
    }

    /// <summary>
    /// Determine if 'word1' and 'word2' are anagrams.  An anagram
    /// is when the same letters in a word are re-organized into a 
    /// new word.  A dictionary is used to solve the problem.
    /// 
    /// Examples:
    /// is_anagram("CAT","ACT") would return true
    /// is_anagram("DOG","GOOD") would return false because GOOD has 2 O's
    /// 
    /// Important Note: When determining if two words are anagrams, you
    /// should ignore any spaces.  You should also ignore cases.  For 
    /// example, 'Ab' and 'Ba' should be considered anagrams
    /// 
    /// Reminder: You can access a letter by index in a string by 
    /// using the [] notation.
    /// </summary>
public static bool IsAnagram(string word1, string word2)
{
    var frequency = new Dictionary<char, int>();
    int count1 = 0, count2 = 0;

    // Process first word: iterate through each character,
    // ignore whitespace, convert to lower case, and update frequency.
    for (int i = 0; i < word1.Length; i++)
    {
        char c = word1[i];
        if (char.IsWhiteSpace(c))
            continue;
        c = char.ToLower(c);
        count1++;
        if (frequency.TryGetValue(c, out int currentCount))
            frequency[c] = currentCount + 1;
        else
            frequency[c] = 1;
    }

    // Process second word: similarly, iterate through each character.
    for (int i = 0; i < word2.Length; i++)
    {
        char c = word2[i];
        if (char.IsWhiteSpace(c))
            continue;
        c = char.ToLower(c);
        count2++;
        if (frequency.TryGetValue(c, out int currentCount))
            frequency[c] = currentCount - 1;
        else
            return false;  // Character in word2 not present in word1.
    }

    // If the normalized lengths differ, they cannot be anagrams.
    if (count1 != count2)
        return false;

    // Finally, ensure that every character count is zero.
    foreach (var kvp in frequency)
    {
        if (kvp.Value != 0)
            return false;
    }
    return true;
}

    /// <summary>
    /// This function will read JSON (Javascript Object Notation) data from the 
    /// United States Geological Service (USGS) consisting of earthquake data.
    /// The data will include all earthquakes in the current day.
    /// 
    /// JSON data is organized into a dictionary. After reading the data using
    /// the built-in HTTP client library, this function will return a list of all
    /// earthquake locations ('place' attribute) and magnitudes ('mag' attribute).
    /// Additional information about the format of the JSON data can be found 
    /// at this website:  
    /// 
    /// https://earthquake.usgs.gov/earthquakes/feed/v1.0/geojson.php
    /// 
    /// </summary>
public static string[] EarthquakeDailySummary()
    {
        const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";
        using var client = new HttpClient();
        using var getRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
        using var response = client.Send(getRequestMessage);
        using var jsonStream = response.Content.ReadAsStream();
        using var reader = new StreamReader(jsonStream);
        var json = reader.ReadToEnd();
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        // Deserialize the JSON into our mapping classes.
        var featureCollection = JsonSerializer.Deserialize<FeatureCollection>(json, options);

        if (featureCollection == null || featureCollection.Features == null)
            return Array.Empty<string>();

        var summaries = new List<string>();
        foreach (var feature in featureCollection.Features)
        {
            // Ensure that both the place and magnitude are available.
            if (feature.Properties != null && 
                !string.IsNullOrEmpty(feature.Properties.Place) &&
                feature.Properties.Mag.HasValue)
            {
                summaries.Add($"{feature.Properties.Place} - Mag {feature.Properties.Mag.Value}");
            }
        }
        return summaries.ToArray();
    }
}
