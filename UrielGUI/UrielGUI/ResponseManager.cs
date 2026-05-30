using System;
using System.Collections.Generic;

namespace UrielGUI
{
    public class ResponseManager
    {
        private Random _rng = new Random();
        private Dictionary<string, List<string>> _responses = new Dictionary<string, List<string>>()
        {
            {"password", new List<string> {
                "Never write down your password on paper. Use a password manager or save it in your phone's secure notes.",
                "A strong password is like a good lock: use at least 12 characters, mix letters, numbers and symbols.",
                "Don't use your birthday, child's name or 'password123'. Scammers guess those easily."
            }},
            {"phishing", new List<string> {
                "Beware of SMS or emails saying your bank account is blocked. Never click the link. Call your bank using the number on your bank card.",
                "Scammers pretend to be from Capitec, FNB, Absa or Standard Bank. They ask for your OTP or PIN. The real bank will never ask.",
                "If you get a WhatsApp from a stranger saying you won a prize, delete it. That's a common trick called 'phishing'."
            }},
            {"malware", new List<string> {
                "Never open attachments from people you don't know. They can install a virus on your phone or computer.",
                "Don't download 'free' apps from unknown websites. Use the official Google Play Store or Apple App Store only.",
                "If your phone starts showing strange ads or runs slowly, you might have malware. Ask a family member to scan it."
            }},
            {"privacy", new List<string> {
                "Be careful what you share on Facebook. Scammers use your photos and information to trick you.",
                "Don't post when you are going on holiday. Thieves watch those posts.",
                "Cover your phone's screen when typing your PIN in public. Someone might be watching."
            }},
            {"browsing", new List<string> {
                "Look for the little padlock icon in your browser's address bar before typing your ID number or bank details.",
                "Don't use public WiFi at malls or taxis for banking. Use your phone's mobile data instead.",
                "Update your phone and apps when it asks. Those updates fix security holes."
            }},
            {"sassa", new List<string> {
                "SASSA will never send you an SMS asking for your ID or PIN. If you get one, ignore it and tell a relative.",
                "Some scammers promise to 'help' you get a SASSA grant faster for a fee. That's a lie. Only go to the official SASSA office.",
                "Your gold card is safe. Never give your card to a stranger, even if they say they work for SASSA."
            }},
            {"lottery", new List<string> {
                "You cannot win a lottery you never entered. Delete those messages immediately.",
                "If someone says you won a car or money but you must pay fees first – that's a scam. Real prizes don't ask for money.",
                "The 'Nigerian prince' email is old but still used. Just delete it."
            }}
        };

        public string GetResponse(string topic)
        {
            if (_responses.TryGetValue(topic.ToLower(), out var list))
                return list[_rng.Next(list.Count)];
            return null;
        }
    }
}