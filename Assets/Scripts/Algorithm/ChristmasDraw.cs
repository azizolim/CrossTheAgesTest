using System;
using System.Collections.Generic;
using UnityEngine;

namespace Algorithm
{
    public class ChristmasDraw : MonoBehaviour
    {
        [SerializeField] private int numParticipants = 47;

        private List<Participant> _participants;

        void Start()
        {
            // Generate data for participants
            _participants = new List<Participant>();
            for (int i = 1; i <= numParticipants; i++)
            {
                Participant participant = new Participant(Guid.NewGuid(), $"participant{i}@example.com", $"First Name {i}", $"Last Name {i}");
                _participants.Add(participant);
            }

            // Run the Christmas draw algorithm
            RunDraw();

            // Print the results
            Debug.Log("The Christmas draw results are:");
            foreach (Participant participant in _participants)
            {
                Debug.Log($"Sender: {participant.FullName}, Receiver: {participant.Receiver.FullName}");
            }
        }

        private void RunDraw()
        {
            // Shuffle the list of participants randomly
            Shuffle(_participants);

            for (int i = 0; i < _participants.Count; i++)
            {
                // Assign the next participant in the shuffled list as the receiver of the gift
                Participant receiver = _participants[(i + 1) % _participants.Count];

                // Check if the assigned receiver is the same as the current participant, if yes
                // then assign the next participant in the shuffled list as the receiver
                while (receiver == _participants[i])
                {
                    receiver = _participants[(i + 2) % _participants.Count];
                }

                // Assign the receiver to the current participant
                _participants[i].Receiver = receiver;
            }
        }

        private void Shuffle<T>(List<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = UnityEngine.Random.Range(0, n + 1);
                (list[k], list[n]) = (list[n], list[k]);
            }
        }
    }
}