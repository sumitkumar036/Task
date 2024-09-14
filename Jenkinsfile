
pipeline {
    agent {label 'windows-cicd'}

    stages
    {
        stage('Git clone clone')
        {
            steps
            {
              echo "printing clone"
            }
        }

        stage('Build')
        {
            steps
            {
                echo "Generating Build"
                script
                {
                    bat '"C:\\Program Files\\Unity\\Hub\\Editor\\2022.3.16f1\\Editor\\Unity.exe" -quit -batchmode -projectPath "C:\ProgramData\Jenkins\node\workspace\Task" -executeMethod GenerateBuild.SimpleBuild'
                }
            }
        }
    }
}
