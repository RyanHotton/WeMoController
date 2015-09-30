import os

# sources:
# http://cmikavac.net/2011/09/11/how-to-generate-an-ip-range-list-in-python/
def ipRange(start_ip, end_ip):
   start = list(map(int, start_ip.split(".")))
   end = list(map(int, end_ip.split(".")))
   temp = start
   ip_range = []
   
   ip_range.append(start_ip)
   while temp != end:
      start[3] += 1
      for i in (3, 2, 1):
         if temp[i] == 256:
            temp[i] = 0
            temp[i-1] += 1
      ip_range.append(".".join(map(str, temp)))    
      
   return ip_range

def isValidIP(hostname):
   response = os.system("ping -c 1 " + hostname)
   if response == 0:
     print hostname, 'is up!'
   else:
     print hostname, 'is down!'  
   
# sample usage 
start_ip = "192.168.1.0"
end_ip = "192.171.3.25"
ip_range = ipRange(start_ip, end_ip)
count = 0
for ip in ip_range:
   #print(ip)
   count += 1
   #isValidIP(ip)
print(count)