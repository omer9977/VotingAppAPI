using VotingAPI.ObsService.Interfaces;
using VotingAPI.ObsService.Services;
using VotingAPI.Tests;

var studentService = new ObsStudentService();

var json = studentService.FindUserByUserName("metinince@std.iyte.edu.tr");

var string1 = "";