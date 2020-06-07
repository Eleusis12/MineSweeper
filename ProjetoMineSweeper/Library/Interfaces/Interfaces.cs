using Library.Helpers;
using Library.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Interfaces
{
	public interface DifficultyView
	{
	}

	public interface LeaderBoardView
	{
		event NotificationTaskHandler AskListViewItems;

		void ShowTop10AccordingtoDifficulty(Dificuldade facil);
	}

	public interface LoginView
	{
		event AccountCredentialsExtractionHandler SendCredentials;

		void Response(bool resposta);
	}

	public interface MainView
	{
	}

	public interface MineSweeperView
	{
		event NotificationTaskHandler AskToResetBoard;
	}

	public interface OptionsView
	{
		event NotificationTaskHandler TurnSoundEffectsInGame;
	}

	public interface RegisterView
	{
		event UserExtractionHandler RegisterThisUser;

		void ResultOfRegistration(string resposta);
	}

	public interface SearchUserView
	{
		event UsernameExtractionHandler AskUserData;

		void ShowProfile(User temp);
	}
}