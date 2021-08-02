#!/usr/bin/env python3

import os
import re

def remove_tanakh():
    os.remove('../output/tanakh.txt')

def merge_tanakh():
    filenames = [
            '../HebrewOT/Genesis.acc.txt',  
            # '../HebrewOT/Exodus.acc.txt',  
            # '../HebrewOT/Leviticus.acc.txt',  
            # '../HebrewOT/Numbers.acc.txt',  
            # '../HebrewOT/Deuteronomy.acc.txt',  
            # '../HebrewOT/Joshua.acc.txt',  
            # '../HebrewOT/Judges.acc.txt',  
            # '../HebrewOT/Samuel_1.acc.txt',  
            # '../HebrewOT/Samuel_2.acc.txt',  
            # '../HebrewOT/Kings_1.acc.txt',  
            # '../HebrewOT/Kings_2.acc.txt',  
            # '../HebrewOT/Isaiah.acc.txt',  
            # '../HebrewOT/Jeremiah.acc.txt',  
            # '../HebrewOT/Ezekiel.acc.txt',  
            # '../HebrewOT/Hosea.acc.txt',  
            # '../HebrewOT/Joel.acc.txt',  
            # '../HebrewOT/Amos.acc.txt',  
            # '../HebrewOT/Obadiah.acc.txt',  
            # '../HebrewOT/Jonah.acc.txt',  
            # '../HebrewOT/Micah.acc.txt',  
            # '../HebrewOT/Nahum.acc.txt',  
            # '../HebrewOT/Habakkuk.acc.txt',  
            # '../HebrewOT/Zephaniah.acc.txt',  
            # '../HebrewOT/Haggai.acc.txt',  
            # '../HebrewOT/Zechariah.acc.txt',  
            # '../HebrewOT/Malachi.acc.txt',  
            # '../HebrewOT/Psalms.acc.txt',  
            # '../HebrewOT/Proverbs.acc.txt',  
            # '../HebrewOT/Job.acc.txt',  
            # '../HebrewOT/Song_of_songs.acc.txt',  
            # '../HebrewOT/Ruth.acc.txt',  
            # '../HebrewOT/Lamentations.acc.txt',  
            # '../HebrewOT/Ecclesiastes.acc.txt',  
            # '../HebrewOT/Esther.acc.txt',  
            # '../HebrewOT/Daniel.acc.txt',  
            # '../HebrewOT/Ezra.acc.txt',  
            # '../HebrewOT/Nehemiah.acc.txt',  
            # '../HebrewOT/Chronicles_1.acc.txt',  
            '../HebrewOT/Chronicles_2.acc.txt']

    with open('../output/tanakh.txt', 'w') as outfile:
        for fname in filenames:
            with open(fname) as infile:
                for line in infile:
                    outfile.write(line)

def clean_tanakh():
    with open ('../output/tanakh.txt', 'r' ) as f:
        content = f.read()
        content_new = re.sub('(x{4}.*)', r'', content, flags = re.M)
        content_new = re.sub('(\[[a-z0-9]\])', r'', content_new, flags = re.M)
        content_new = re.sub('([0-9:\s])', r'', content_new, flags = re.M)
        content_new = re.sub('([׃])', r'', content_new, flags = re.M)

    with open ('../output/tanakh.txt', 'w' ) as outfile:
        outfile.write(content_new)

remove_tanakh()
merge_tanakh()
clean_tanakh()
