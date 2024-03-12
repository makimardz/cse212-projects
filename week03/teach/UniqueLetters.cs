public static class UniqueLetters {
    public static void Run() {
        var test1 = "abcdefghjiklmnopqrstuvwxyz"; // Expect True because all letters unique
        Console.WriteLine(AreUniqueLetters(test1));

        var test2 = "abcdefghjiklanopqrstuvwxyz"; // Expect False because 'a' is repeated
        Console.WriteLine(AreUniqueLetters(test2));

        var test3 = "";
        Console.WriteLine(AreUniqueLetters(test3)); // Expect True because its an empty string
    }

    /// <summary>Determine if there are any duplicate letters in the text provided</summary>
    /// <param name="text">Text to check for duplicate letters</param>
    /// <returns>true if all letters are unique, otherwise false</returns>
    private static bool AreUniqueLetters(string text) {
        // TODO Problem 1 - Replace the O(n^2) algorithm to use sets and O(n) efficiency
        // Create a HashSet to store unique characters encountered
    var uniqueCharacters = new HashSet<char>();

    // Iterate through each character in the string
    foreach (char c in text) {
        // If the character is already in the set, it means it's a duplicate
        if (uniqueCharacters.Contains(c))
            return false;

        // Otherwise, add the character to the set
        uniqueCharacters.Add(c);
    }

    // If no duplicates were found, return true
    return true;
    }
}