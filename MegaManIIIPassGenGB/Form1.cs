/**
 *  @file           Form1.cs / FormMegaManIIIPassGenGB
 *  @brief          Password Generator for the Nintendo Gameboy Game MegaMan III
 *  @copyright      Shawn M. Crawford 2019
 *  @date           04/11/2019
 *
 *  @remark Author  Shawn M. Crawford (sleepy9090)
 *
 *  @note           N/A
 *
 */
using System;
using System.Windows.Forms;

namespace MegaManIIIPassGenGB
{
    public partial class FormMegaManIIIPassGenGB : Form
    {
        public FormMegaManIIIPassGenGB()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            DisablePasswordCheckboxes();
        }

        private void DisablePasswordCheckboxes()
        {
            checkBoxA0.Enabled = false;
            checkBoxA1.Enabled = false;
            checkBoxA2.Enabled = false;
            checkBoxA3.Enabled = false;

            checkBoxB0.Enabled = false;
            checkBoxB1.Enabled = false;
            checkBoxB2.Enabled = false;
            checkBoxB3.Enabled = false;

            checkBoxC0.Enabled = false;
            checkBoxC1.Enabled = false;
            checkBoxC2.Enabled = false;
            checkBoxC3.Enabled = false;

            checkBoxD0.Enabled = false;
            checkBoxD1.Enabled = false;
            checkBoxD2.Enabled = false;
            checkBoxD3.Enabled = false;
        }

        private void ClearPasswordCheckboxes()
        {
            checkBoxA0.Checked = false;
            checkBoxA1.Checked = false;
            checkBoxA2.Checked = false;
            checkBoxA3.Checked = false;

            checkBoxB0.Checked = false;
            checkBoxB1.Checked = false;
            checkBoxB2.Checked = false;
            checkBoxB3.Checked = false;

            checkBoxC0.Checked = false;
            checkBoxC1.Checked = false;
            checkBoxC2.Checked = false;
            checkBoxC3.Checked = false;

            checkBoxD0.Checked = false;
            checkBoxD1.Checked = false;
            checkBoxD2.Checked = false;
            checkBoxD3.Checked = false;
        }

        private int getTotalChecked1()
        {
            int totalChecked = 0;

            if (checkBoxSearchSnake.Checked)
            {
                totalChecked++;
            }

            if (checkBoxGeminiLaser.Checked)
            {
                totalChecked++;
            }

            if (checkBoxShadowBlade.Checked)
            {
                totalChecked++;
            }

            if (checkBoxSparkShock.Checked)
            {
                totalChecked++;
            }

            return totalChecked;
        }

        private int getTotalChecked2()
        {
            int totalChecked = 0;

            if (checkBoxDustCrusher.Checked)
            {
                totalChecked++;
            }

            if (checkBoxSkullBarrier.Checked)
            {
                totalChecked++;
            }

            if (checkBoxDiveMissile.Checked)
            {
                totalChecked++;
            }

            if (checkBoxDrillBomb.Checked)
            {
                totalChecked++;
            }

            return totalChecked;
        }

        private void buttonGenerate_Click(object sender, EventArgs e)
        {
            ClearPasswordCheckboxes();

            bool hasSearchSnake = checkBoxSearchSnake.Checked;
            bool hasGeminiLaser = checkBoxGeminiLaser.Checked;
            bool hasShadowBlade = checkBoxShadowBlade.Checked;
            bool hasSparkShock = checkBoxSparkShock.Checked;
            bool wily1StageCompleted = checkBoxWilyFortress1.Checked;
            bool hasDustCrusher = checkBoxDustCrusher.Checked;
            bool hasSkullbarrier = checkBoxSkullBarrier.Checked;
            bool hasDiveMissile = checkBoxDiveMissile.Checked;
            bool hasDrillBomb = checkBoxDrillBomb.Checked;

            // If any of the last four weapons are selected or the wily fortress stage 1 is completed, then the first four weapons must be selected as well.
            if ((wily1StageCompleted || hasDustCrusher || hasSkullbarrier || hasDiveMissile || hasDrillBomb) &&
                    (!hasSearchSnake || !hasGeminiLaser || !hasShadowBlade || !hasSparkShock || !wily1StageCompleted))
            {
                MessageBox.Show("Selecting secondary weapons or completing the Wily Fortress Stage 1 requires acquirement of all the primary weapons as well as the completed Wily Fortress Stage 1 option.",
                    "Info",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1);

                checkBoxSearchSnake.Checked = true;
                checkBoxGeminiLaser.Checked = true;
                checkBoxShadowBlade.Checked = true;
                checkBoxSparkShock.Checked = true;
                checkBoxWilyFortress1.Checked = true;

                return;
            }

            if (!wily1StageCompleted)
            {
                int totalChecked = getTotalChecked1();

                if (totalChecked == 4)
                {
                    checkBoxA1.Checked = true;
                    checkBoxB0.Checked = true;
                    checkBoxB1.Checked = true;
                    checkBoxC1.Checked = true;
                    checkBoxD1.Checked = true;
                }
                else if (totalChecked == 3)
                {
                    if (hasSearchSnake && hasSparkShock && hasGeminiLaser)
                    {
                        checkBoxA2.Checked = true;
                        checkBoxB1.Checked = true;
                        checkBoxC3.Checked = true;
                        checkBoxD2.Checked = true;
                        checkBoxD3.Checked = true;
                    }
                    else if (hasSparkShock && hasShadowBlade && hasGeminiLaser)
                    {
                        checkBoxA0.Checked = true;
                        checkBoxA1.Checked = true;
                        checkBoxA3.Checked = true;
                        checkBoxB0.Checked = true;
                        checkBoxC0.Checked = true;
                    }
                    else if (hasSearchSnake && hasShadowBlade && hasGeminiLaser)
                    {
                        checkBoxA1.Checked = true;
                        checkBoxA3.Checked = true;
                        checkBoxB1.Checked = true;
                        checkBoxB3.Checked = true;
                        checkBoxD1.Checked = true;
                    }
                    else if (hasSearchSnake && hasShadowBlade && hasSparkShock)
                    {
                        checkBoxA3.Checked = true;
                        checkBoxB3.Checked = true;
                        checkBoxC2.Checked = true;
                        checkBoxC3.Checked = true;
                        checkBoxD2.Checked = true;
                    }
                }
                else if (totalChecked == 2)
                {
                    if (hasSearchSnake && hasSparkShock)
                    {
                        checkBoxA0.Checked = true;
                        checkBoxB0.Checked = true;
                        checkBoxB3.Checked = true;
                        checkBoxD0.Checked = true;
                        checkBoxD1.Checked = true;
                    }
                    else if (hasSearchSnake && hasShadowBlade)
                    {
                        checkBoxB3.Checked = true;
                        checkBoxC1.Checked = true;
                        checkBoxC3.Checked = true;
                        checkBoxD1.Checked = true;
                        checkBoxD2.Checked = true;
                    }
                    else if (hasSearchSnake && hasGeminiLaser)
                    {
                        checkBoxA2.Checked = true;
                        checkBoxB2.Checked = true;
                        checkBoxD1.Checked = true;
                        checkBoxD2.Checked = true;
                        checkBoxD3.Checked = true;
                    }
                    else if (hasSparkShock && hasShadowBlade)
                    {
                        checkBoxB1.Checked = true;
                        checkBoxC0.Checked = true;
                        checkBoxC3.Checked = true;
                        checkBoxD2.Checked = true;
                        checkBoxD3.Checked = true;
                    }
                    else if (hasSparkShock && hasGeminiLaser)
                    {
                        checkBoxB1.Checked = true;
                        checkBoxC0.Checked = true;
                        checkBoxC2.Checked = true;
                        checkBoxC3.Checked = true;
                        checkBoxD1.Checked = true;
                    }
                    else if (hasShadowBlade && hasGeminiLaser)
                    {
                        checkBoxB0.Checked = true;
                        checkBoxB1.Checked = true;
                        checkBoxC0.Checked = true;
                        checkBoxC3.Checked = true;
                        checkBoxD2.Checked = true;
                    }
                }
                else if (totalChecked == 1)
                {
                    if (hasSearchSnake)
                    {
                        checkBoxA0.Checked = true;
                        checkBoxA1.Checked = true;
                        checkBoxA3.Checked = true;
                        checkBoxB3.Checked = true;
                        checkBoxD2.Checked = true;
                    }
                    else if (hasSparkShock)
                    {
                        checkBoxA2.Checked = true;
                        checkBoxB3.Checked = true;
                        checkBoxC0.Checked = true;
                        checkBoxC3.Checked = true;
                        checkBoxD2.Checked = true;
                    }
                    else if (hasShadowBlade)
                    {
                        checkBoxA0.Checked = true;
                        checkBoxC0.Checked = true;
                        checkBoxC1.Checked = true;
                        checkBoxC3.Checked = true;
                        checkBoxD3.Checked = true;
                    }
                    else if (hasGeminiLaser)
                    {
                        checkBoxA1.Checked = true;
                        checkBoxA3.Checked = true;
                        checkBoxB3.Checked = true;
                        checkBoxC0.Checked = true;
                        checkBoxD1.Checked = true;
                    }
                }
                else if (totalChecked == 0)
                {
                    checkBoxA0.Checked = true;
                    checkBoxB0.Checked = true;
                    checkBoxB1.Checked = true;
                    checkBoxB3.Checked = true;
                    checkBoxD3.Checked = true;
                }
            }
            else
            {
                int totalChecked = getTotalChecked2();

                if (totalChecked == 4)
                {
                    checkBoxA0.Checked = true;
                    checkBoxB0.Checked = true;
                    checkBoxB2.Checked = true;
                    checkBoxC1.Checked = true;
                    checkBoxC2.Checked = true;
                }
                else if (totalChecked == 3)
                {
                    if (hasDustCrusher && hasSkullbarrier && hasDiveMissile)
                    {
                        checkBoxA1.Checked = true;
                        checkBoxA2.Checked = true;
                        checkBoxB3.Checked = true;
                        checkBoxC2.Checked = true;
                        checkBoxD3.Checked = true;
                    }
                    else if (hasDustCrusher && hasDiveMissile && hasDrillBomb)
                    {
                        checkBoxB0.Checked = true;
                        checkBoxB1.Checked = true;
                        checkBoxB3.Checked = true;
                        checkBoxC1.Checked = true;
                        checkBoxD0.Checked = true;
                    }
                    else if (hasDustCrusher && hasSkullbarrier && hasDrillBomb)
                    {
                        checkBoxA0.Checked = true;
                        checkBoxA3.Checked = true;
                        checkBoxB0.Checked = true;
                        checkBoxB3.Checked = true;
                        checkBoxD2.Checked = true;
                    }
                    else if (hasDiveMissile && hasDrillBomb && hasSkullbarrier)
                    {
                        checkBoxA1.Checked = true;
                        checkBoxB0.Checked = true;
                        checkBoxB3.Checked = true;
                        checkBoxC1.Checked = true;
                        checkBoxD0.Checked = true;
                    }
                }
                else if (totalChecked == 2)
                {
                    if (hasDustCrusher && hasSkullbarrier)
                    {
                        checkBoxA1.Checked = true;
                        checkBoxB3.Checked = true;
                        checkBoxC2.Checked = true;
                        checkBoxC3.Checked = true;
                        checkBoxD3.Checked = true;
                    }
                    else if (hasDustCrusher && hasDiveMissile)
                    {
                        checkBoxA2.Checked = true;
                        checkBoxB3.Checked = true;
                        checkBoxC0.Checked = true;
                        checkBoxD0.Checked = true;
                        checkBoxD3.Checked = true;
                    }
                    else if (hasDustCrusher && hasDrillBomb)
                    {
                        checkBoxA0.Checked = true;
                        checkBoxB1.Checked = true;
                        checkBoxC0.Checked = true;
                        checkBoxC1.Checked = true;
                        checkBoxD2.Checked = true;
                    }
                    else if (hasSkullbarrier && hasDiveMissile)
                    {
                        checkBoxA0.Checked = true;
                        checkBoxA3.Checked = true;
                        checkBoxC1.Checked = true;
                        checkBoxC2.Checked = true;
                        checkBoxD1.Checked = true;
                    }
                    else if (hasSkullbarrier && hasDrillBomb)
                    {
                        checkBoxA1.Checked = true;
                        checkBoxB2.Checked = true;
                        checkBoxC2.Checked = true;
                        checkBoxD0.Checked = true;
                        checkBoxD3.Checked = true;
                    }
                    else if (hasDiveMissile && hasDrillBomb)
                    {
                        checkBoxB0.Checked = true;
                        checkBoxC0.Checked = true;
                        checkBoxC1.Checked = true;
                        checkBoxC3.Checked = true;
                        checkBoxD0.Checked = true;
                    }
                }
                else if (totalChecked == 1)
                {
                    if (hasDustCrusher)
                    {
                        checkBoxA2.Checked = true;
                        checkBoxA3.Checked = true;
                        checkBoxB3.Checked = true;
                        checkBoxC0.Checked = true;
                        checkBoxC3.Checked = true;
                    }
                    else if (hasSkullbarrier)
                    {
                        checkBoxB0.Checked = true;
                        checkBoxB1.Checked = true;
                        checkBoxC2.Checked = true;
                        checkBoxD0.Checked = true;
                        checkBoxD3.Checked = true;
                    }
                    else if (hasDiveMissile)
                    {
                        checkBoxB0.Checked = true;
                        checkBoxB3.Checked = true;
                        checkBoxC0.Checked = true;
                        checkBoxC1.Checked = true;
                        checkBoxD2.Checked = true;
                    }
                    else if (hasDrillBomb)
                    {
                        checkBoxA1.Checked = true;
                        checkBoxB0.Checked = true;
                        checkBoxC0.Checked = true;
                        checkBoxC1.Checked = true;
                        checkBoxD3.Checked = true;
                    }
                }
                else if (totalChecked == 0)
                {
                    checkBoxA2.Checked = true;
                    checkBoxB1.Checked = true;
                    checkBoxB2.Checked = true;
                    checkBoxC0.Checked = true;
                    checkBoxD1.Checked = true;
                }
            }

        }
    }
}
