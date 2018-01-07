echo "====================="
echo "====== Volumes ======"
echo "====================="
docker volume create --name=sqlserverdata
docker volume create --name=rabbitmqdata

echo ""
echo "=============================="
echo "====== Exchange Service ======"
echo "=============================="
cd ExchangeService
./RebuildDockerImage.ps1
cd ..

