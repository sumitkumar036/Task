
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
    }

    stage('Build')
    {
        steps
        {
            script
            {
                bat '"C:\\Program Files\\Unity\\Hub\\Editor\\2022.3.16f1\\Editor\\Unity.exe" -quit -batchmode -projectPath "C:\\All Unity Data\\Projects\\HP" -executeMethod GenerateBuild.SimpleBuild'
            }
        }
    }
}
