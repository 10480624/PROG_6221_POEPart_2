namespace RaphaelGUI
{
    // This class satisfies the POE random responses requirement
    // It stores multiple responses for each cybersecurity topic
    // and randomly selects one to keep conversations fresh and engaging
    // It uses Lists which satisfies the POE generic collections requirement
    internal class ResponseManager
    {
        // Each of these lists stores multiple responses for one topic
        // Having multiple responses means the bot never sounds repetitive
        // Lists are used here to satisfy the POE generic collections requirement
        private List<string> _phishingResponses { get; set; }
        private List<string> _passwordResponses { get; set; }
        private List<string> _privacyResponses { get; set; }
        private List<string> _malwareResponses { get; set; }
        private List<string> _safeBrowsingResponses { get; set; }

        // Random object used to pick responses from the lists
        private Random _random { get; set; }

        // Constructor fills all response lists with multiple tips
        // South African context is included where relevant
        public ResponseManager()
        {
            // PSEUDOCODE:
            // INITIALISE random number generator

            // FILL _phishingResponses with tips such as:
            //     "Be cautious of emails asking for personal information.
            //      Scammers often disguise themselves as trusted organisations."
            //     "Never click links in unexpected emails or SMSs.
            //      Banks and SARS will never ask for your PIN via a link."
            //     "Check the sender email address carefully.
            //      Scammers use addresses that look almost correct but are slightly different."
            //     "If an offer seems too good to be true it probably is.
            //      This is a common tactic used in South African phishing scams."

            // FILL _passwordResponses with tips such as:
            //     "Use strong unique passwords for each account.
            //      Avoid using personal info like your birthdate or ID number."
            //     "A password manager can help you store and generate secure passwords."
            //     "Never share your password with anyone including family members."
            //     "Use a combination of letters numbers and symbols for stronger passwords."

            // FILL _privacyResponses with tips such as:
            //     "Review your social media privacy settings regularly."
            //     "Do not share your ID number or banking details on public platforms."
            //     "Be careful what personal information you post online."
            //     "South African law protects your personal information under POPIA."

            // FILL _malwareResponses with tips such as:
            //     "Keep your antivirus software updated at all times."
            //     "Never download attachments from unknown or unexpected senders."
            //     "Avoid clicking on suspicious pop-up windows or ads."
            //     "Malware can steal your banking details without you knowing."

            // FILL _safeBrowsingResponses with tips such as:
            //     "Only visit websites with HTTPS and the padlock icon in the address bar."
            //     "Avoid doing your banking or shopping on public Wi-Fi."
            //     "Keep your browser and operating system updated."
            //     "Use a VPN when connecting to public networks for extra security."
        }

        // This method picks a random response for a given topic
        // Called by CyberBot when a keyword is detected
        public string GetRandomResponse(string topic)
        {
            // PSEUDOCODE:
            // FIND the list matching the topic
            // IF list found
            //     PICK a random index between 0 and list length
            //     RETURN the response at that index
            // ELSE
            //     RETURN default fallback response
            return string.Empty;
        }

        // This method picks a different random response for follow up questions
        // Called when user says "tell me more" or "another tip"
        public string GetFollowUpResponse(string topic)
        {
            // PSEUDOCODE:
            // Same as GetRandomResponse but ensures a different response
            // is returned by tracking the last response index
            return string.Empty;
        }

        // This method checks if a topic has responses available
        // Used by CyberBot before trying to get a response
        public bool TopicExists(string topic)
        {
            // PSEUDOCODE:
            // IF topic matches any known list name
            //     RETURN true
            // ELSE
            //     RETURN false
            return false;
        }
    }
}
